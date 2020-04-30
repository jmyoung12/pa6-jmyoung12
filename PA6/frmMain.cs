using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA6
{
    public partial class frmMain : Form
    {
        string cwid;
        List<Book> myBooks;

        public frmMain(string cwid)
        {
            this.cwid = cwid;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadBooks()
        {
            // Load books from API
            myBooks = BookFile.GetAllBooks(cwid);
            lbBooks.DataSource = myBooks;
        }

        private void lbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var book = (Book)lbBooks.SelectedItem;

                tbAuthor.Text = book.author;
                tbCopies.Text = book.copies.ToString();
                tbGenre.Text = book.genre;
                tbISBN.Text = book.isbn;
                tbLength.Text = book.length.ToString();
                tbTitle.Text = book.title;

                pbCover.Load(book.cover);
            }
            catch(Exception exc)
            {
                
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                var book = new Book();

                frmEdit newForm = new frmEdit(book, cwid);
                if (newForm.ShowDialog() == DialogResult.OK)
                {
                    var editedBook = (Book)newForm.Tag;

                    BookFile.SaveBook(editedBook, cwid, "");

                    LoadBooks();
                }
            }
            catch (Exception exc) { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {               
                var book = (Book)lbBooks.SelectedItem;

                frmEdit editForm = new frmEdit(book, cwid);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    var editedBook = (Book)editForm.Tag;

                    BookFile.SaveBook(editedBook, cwid, "edit");

                    LoadBooks();
                }
            }
            catch (Exception exc) { }
        }

        private void btnRent_Click(object sender, EventArgs e)
        {
            try
            {
                var book = (Book)lbBooks.SelectedItem;

                if(book.copies > 0)
                    book.copies--;

                BookFile.SaveBook(book, cwid, "edit");

                LoadBooks();
            }
            catch (Exception exc) { }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                var book = (Book)lbBooks.SelectedItem;

                    book.copies++;

                BookFile.SaveBook(book, cwid, "edit");

                LoadBooks();
            }
            catch (Exception exc)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var book = (Book)lbBooks.SelectedItem;

                BookFile.DeleteBook(book, cwid);

                LoadBooks();
            }
            catch (Exception exc)
            {

            }
        }
    }
}
