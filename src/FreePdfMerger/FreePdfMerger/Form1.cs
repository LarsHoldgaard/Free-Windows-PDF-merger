using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace FreePdfMerger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Enable drag & drop
            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in droppedFiles)
            {
                if (Path.GetExtension(filePath).Equals(".pdf", StringComparison.OrdinalIgnoreCase))
                {
                    AddPdfFileToList(filePath);
                }
            }
            UpdateTotalPageCount();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PDF Files|*.pdf";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        AddPdfFileToList(filePath);
                    }
                    UpdateTotalPageCount();
                }
            }
        }

        private void AddPdfFileToList(string filePath)
        {
            var lvi = new ListViewItem(filePath);
            listViewPDFFiles.Items.Add(lvi);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listViewPDFFiles.SelectedItems.Count == 0) return;
            int index = listViewPDFFiles.SelectedItems[0].Index;
            if (index == 0) return; // already at top

            ListViewItem selected = listViewPDFFiles.SelectedItems[0];
            listViewPDFFiles.Items.Remove(selected);
            listViewPDFFiles.Items.Insert(index - 1, selected);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listViewPDFFiles.SelectedItems.Count == 0) return;
            int index = listViewPDFFiles.SelectedItems[0].Index;
            if (index == listViewPDFFiles.Items.Count - 1) return; // already at bottom

            ListViewItem selected = listViewPDFFiles.SelectedItems[0];
            listViewPDFFiles.Items.Remove(selected);
            listViewPDFFiles.Items.Insert(index + 1, selected);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            if (listViewPDFFiles.Items.Count == 0)
            {
                MessageBox.Show("No PDF files to merge.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF Files|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string outputFilePath = sfd.FileName;
                    MergePdfFiles(outputFilePath);
                    MessageBox.Show("Merged PDF saved to: " + outputFilePath);
                }
            }
        }

        private void MergePdfFiles(string destinationPath)
        {
            // Merge with PDFsharp
            using (PdfDocument outputDocument = new PdfDocument())
            {
                foreach (ListViewItem item in listViewPDFFiles.Items)
                {
                    using (PdfDocument inputDocument = PdfReader.Open(item.Text, PdfDocumentOpenMode.Import))
                    {
                        // Add each page from input to output
                        foreach (PdfPage page in inputDocument.Pages)
                        {
                            outputDocument.AddPage(page);
                        }
                    }
                }
                outputDocument.Save(destinationPath);
            }
        }

        private void UpdateTotalPageCount()
        {
            int totalPages = 0;
            foreach (ListViewItem item in listViewPDFFiles.Items)
            {
                using (PdfDocument doc = PdfReader.Open(item.Text, PdfDocumentOpenMode.InformationOnly))
                {
                    totalPages += doc.PageCount;
                }
            }
            lblTotalPages.Text = "Total Pages: " + totalPages;
        }
    }
}