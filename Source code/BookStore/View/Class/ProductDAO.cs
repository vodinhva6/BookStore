using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookStore.View.Class
{
    public class ProductDAO
    {
        public ObservableCollection<Category> _categories = null;

        ObservableCollection<Book> _books = null;

        public Price _price = null;

        public static DBContext _db;

        public ProductDAO()
        {
            _books = new ObservableCollection<Book>();
            _categories = new ObservableCollection<Category>() { new Category() { CategoryID = 0, CategoryName = "All" } };
            _db = new DBContext();
            if (!_db.Database.CanConnect())
            {
                System.Windows.Forms.MessageBox.Show("DB connection is bad");
            }

            //Read Book data
            List<Book> _temp_books = _db.getAllBooks();
            foreach (var book in _temp_books)
            {
                _books.Add(book);
            }

            //Read Category data
            List<Category> _temp_categories = _db.getCategories();
            foreach (var category in _temp_categories)
            {
                _categories.Add(category);
            }

            //Read Price data
            _price = new Price();
            resetPrice();
        }

        private ObservableCollection<Book> convertObservable(IEnumerable<Book> books)
        {
            ObservableCollection<Book> result = new ObservableCollection<Book>();
            foreach(Book book in books)
            {
                result.Add(book);
            }
            return result;
        }

        public Tuple<ObservableCollection<Book>, int> getAll(int currentPage = 1, int rowsPerPage = 10, string keyword = "", int type = 0, int price = -1)
        {
            var result = _books.Where(item => item.Name.Contains(keyword));
            if (price != -1)
            {
                result = result.Where(item => int.Parse(item.Price) <= price);
            }
            if(type != 0)
            {
                result = result.Where(item => item.CategoryID == type);
            }
            int totalItems = result.Count();
            result = result.Skip((currentPage - 1) * rowsPerPage).Take(rowsPerPage);
            return new Tuple<ObservableCollection<Book>, int>(convertObservable(result), totalItems); 
        }

  
        public Tuple<ObservableCollection<Book>, int> getFiveOutOfStock()
        {
            //ObservableCollection<Book> result = new ObservableCollection<Book>();
            var tmp = _books.OrderBy(item => item.Quantity);
            var result = tmp.Where(item => int.Parse(item.Quantity) < 5).Skip(0).Take(5);
            var totalProducts = tmp.Count();
            return new Tuple<ObservableCollection<Book>, int>( convertObservable(result), totalProducts);
        }

        public void import()
        {
            string filename = "";
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Excel files (*.csv;*.xlsx)|*.csv;*.xlsx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
            }

            if (filename.IsNullOrEmpty() || !filename.EndsWith(".xlsx")) return;

            //delete _books
            _books.Clear();

            //delete _categories
            _categories.Clear();
            _categories.Add(new Category() { CategoryID = 0, CategoryName = "All" });

            //delete db
            _db.Categories.RemoveRange(_db.Categories);
            _db.Books.RemoveRange(_db.Books);
            _db.SaveChanges();

            var document = SpreadsheetDocument.Open(filename, false);
            var wbPart = document.WorkbookPart!;
            var sheets = wbPart.Workbook.Descendants<Sheet>()!;

            //Read Category Sheet
            var sheet = sheets.FirstOrDefault(s => s.Name == "Category");
            var wsPart = (WorksheetPart)(wbPart!.GetPartById(sheet.Id!));
            var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
            var cells = wsPart.Worksheet.Descendants<Cell>();

            Cell idCell;
            int row = 2;
            do
            {
                idCell = cells.FirstOrDefault(c => c?.CellReference == $"A{row}")!;

                if (idCell?.InnerText.Length > 0)
                {
                    Cell nameCell = cells.FirstOrDefault(c => c?.CellReference == $"B{row}")!;
                    string nameID = nameCell!.InnerText;
                    string name = stringTable.SharedStringTable.ElementAt(int.Parse(nameID)).InnerText;

                    var category = new Category() { CategoryID = int.Parse(idCell.InnerText), CategoryName = name };
                    _categories.Add(category);
                    _db.insertCategory(category);
                }
                row++;

            } while (idCell?.InnerText.Length > 0);

            //Read Product Sheet
            sheet = sheets.FirstOrDefault(s => s.Name == "Product");
            wsPart = (WorksheetPart)(wbPart!.GetPartById(sheet.Id!));
            stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault()!;
            cells = wsPart.Worksheet.Descendants<Cell>();

            row = 2;
            do
            {
                idCell = cells.FirstOrDefault(c => c?.CellReference == $"A{row}")!;

                if (idCell?.InnerText.Length > 0)
                {
                    Cell nameCell = cells.FirstOrDefault(c => c?.CellReference == $"B{row}")!;
                    string nameID = nameCell!.InnerText;
                    string name = stringTable.SharedStringTable.ElementAt(int.Parse(nameID)).InnerText;

                    Cell imageCell = cells.FirstOrDefault(c => c?.CellReference == $"C{row}")!;
                    string imageID = imageCell!.InnerText;
                    string image = stringTable.SharedStringTable.ElementAt(int.Parse(imageID)).InnerText;

                    Cell authorCell = cells.FirstOrDefault(c => c?.CellReference == $"D{row}")!;
                    string authorID = authorCell!.InnerText;
                    string author = stringTable.SharedStringTable.ElementAt(int.Parse(authorID)).InnerText;

                    Cell publishCell = cells.FirstOrDefault(c => c?.CellReference == $"E{row}")!;
                    string publish = publishCell!.InnerText;

                    Cell categoryIDCell = cells.FirstOrDefault(c => c?.CellReference == $"F{row}")!;
                    string categoryID = categoryIDCell!.InnerText;

                    Cell priceCell = cells.FirstOrDefault(c => c?.CellReference == $"G{row}")!;
                    string price = priceCell!.InnerText;

                    Cell rawPriceCell = cells.FirstOrDefault(c => c?.CellReference == $"H{row}")!;
                    string rawPrice = rawPriceCell!.InnerText;

                    Cell quantityCell = cells.FirstOrDefault(c => c?.CellReference == $"I{row}")!;
                    string quantity = quantityCell!.InnerText;

                    var book = new Book() { ID = int.Parse(idCell!.InnerText), Name = name, Author = author, Image = image, Publish = publish, CategoryID = int.Parse(categoryID), Price = price, RawPrice = rawPrice, Quantity = quantity };
                    _books.Add(book);
                    _db.insertBook(book);
                }
                row++;

            } while (idCell?.InnerText.Length > 0);
            resetPrice();
        }

        private void resetPrice()
        {
            if (_books.Count == 0) return;
            _price.maxPrice = _books.Max(book => int.Parse(book.Price));
            _price.minPrice = _books.Min(book => int.Parse(book.Price));
            _price.currentPrice = _price.maxPrice;
        }

        public void addProduct()
        {
            int productID = 1;
            if (_books.Count > 0)
            {
                productID = _books.Last().ID + 1;
            }
            AddProduct addProduct = new AddProduct(productID, _categories);
            bool? result = addProduct.ShowDialog();
            if (result == true)
            {
                _books.Add(addProduct.book);
                _db.insertBook(addProduct.book);
                resetPrice();
            }
        }

        public void deleteProduct(int bookID)
        {
            int index = _books.IndexOf(_books.First(book => book.ID == bookID));
            _db.deleteBook(_books[index]);
            _books.RemoveAt(index);
            resetPrice();
        }

        public void updateProduct(int bookID)
        {
            int index = _books.IndexOf(_books.First(book => book.ID == bookID));
            UpdateProduct updateProduct = new UpdateProduct(_books[index], _categories);
            bool? result = updateProduct.ShowDialog();
            if (result == true)
            {
                _books[index] = updateProduct.book;
                _db.updateBook(_books[index]);
                resetPrice();
            }
        }

        public void addCategory()
        {
            int categoryID = 1;
            if (_categories.Count > 0)
            {
                categoryID = _categories.Last().CategoryID + 1;
            }
            AddCategory addCategory = new AddCategory(categoryID);
            bool? result = addCategory.ShowDialog();
            if (result == true)
            {
                _categories.Add(addCategory.category);
                _db.insertCategory(addCategory.category);
            }
        }

        public void deleteCategory()
        {
            DeleteCategory deleteCategory = new DeleteCategory(_categories);
            bool? result = deleteCategory.ShowDialog();
            if (result == true)
            {
                _db.deleteCategory(_categories[deleteCategory.selectedCategoryIndex]);
                _categories.RemoveAt(deleteCategory.selectedCategoryIndex);
            }
        }

        public void updateCategory()
        {
            UpdateCategory updateCategory = new UpdateCategory(_categories);
            bool? result = updateCategory.ShowDialog();
            if (result == true)
            {
                _categories[updateCategory.selectedCategoryIndex] = updateCategory.category;
                _db.updateCategory(updateCategory.selectedCategoryIndex);
            }
        }

        public void resetCategory()
        {
            _categories.Clear();
            //Read Category data
            List<Category> _temp_categories = _db.getCategories();
            foreach (var category in _temp_categories)
            {
                _categories.Add(category);
            }
        }
    }
}
