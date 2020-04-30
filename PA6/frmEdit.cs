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
    public partial class frmEdit : Form
    {
        Book book;
        string cwid;

        public frmEdit(Book book, string cwid)
        {            
            this.cwid = cwid;
            this.book = book;
            InitializeComponent();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {
            tbAuthor.Text = book.author;
            tbCopies.Text = book.copies.ToString();
            tbGenre.Text = book.genre;
            tbISBN.Text = book.isbn;
            tbLength.Text = book.length.ToString();
            tbTitle.Text = book.title;
            tbCover.Text = book.cover;

            if (!string.IsNullOrEmpty(book.cover))
                pbCover.Load(book.cover);           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            book.author = tbAuthor.Text;
            book.copies = int.Parse(tbCopies.Text);
            book.genre = tbGenre.Text;
            book.isbn = tbISBN.Text;
            book.length = int.Parse(tbLength.Text);
            book.title = tbTitle.Text;
            book.cover = tbCover.Text;
            book.cwid = cwid;

            this.Tag = book;
            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
