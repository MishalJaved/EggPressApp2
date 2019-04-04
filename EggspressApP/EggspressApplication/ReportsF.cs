using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Sql;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace EggspressApplication
{
    public partial class ReportsF : Form
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2H5KOKN;Initial Catalog=EPMS;Integrated Security=True");

        private string userType = "";
       
        public ReportsF(string type)
        {
            InitializeComponent();
            this.userType = type;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menu m = new menu(userType);
            this.Hide();
            m.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportsF_Load(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                {
                    //View All Data of Sale_Report_.........................
                    conn.Open();
                    cmd = new SqlCommand("Select Type,Units,TotalAmount from Sale_tbl where Date between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView1.DataSource = dt;
                    conn.Close();
                }
            // Datagridview1 Total Calculation(Sale Report)......................
            {
                dataGridView1[0, dataGridView1.Rows.Count - 1].Value = "Total";
                decimal total1 = 0;
                decimal total2 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    var value = dataGridView1.Rows[i].Cells[1].Value;
                    var value1 = dataGridView1.Rows[i].Cells[2].Value;

                    if (value != DBNull.Value)
                    {
                        total1 += Convert.ToDecimal(value);
                    }
                    if (value1 != DBNull.Value)
                    {
                        total2 += Convert.ToDecimal(value1);
                    }
                }
                if (total1 == 0 | total2 == 0)
                {
                }
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = total1.ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = total2.ToString();
            }

            {
                    //View All Data of Purchase Report_table.........................
                    conn.Open();
                    cmd = new SqlCommand("Select Farm_name,Type,Units,TotalAmount,QtyDamage,DamageAmount from Purchase2_tbl where Date between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView2.DataSource = dt;
                    conn.Close();
                }
            // Datagridview2 Total Calculation(Purchase Report)......................
            {
                dataGridView2[1, dataGridView2.Rows.Count - 1].Value = "Total";
                decimal unitstotal = 0;
                decimal amounttotal = 0;
                decimal qtydmg = 0;
                decimal dmgamount = 0;
                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    var value = dataGridView2.Rows[i].Cells[2].Value;
                    var value1 = dataGridView2.Rows[i].Cells[3].Value;
                    var value2 = dataGridView2.Rows[i].Cells[4].Value;
                    var value3 = dataGridView2.Rows[i].Cells[5].Value;

                    if (value != DBNull.Value | value1 != DBNull.Value | value2 != DBNull.Value | value3 != DBNull.Value)
                    {
                        unitstotal += Convert.ToDecimal(value);
                        amounttotal += Convert.ToDecimal(value1);
                        qtydmg += Convert.ToDecimal(value2);
                        dmgamount += Convert.ToDecimal(value3);
                    }
                    
                }
                if (unitstotal == 0 | amounttotal == 0 | qtydmg == 0| dmgamount==0)
                {

                }
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[2].Value = unitstotal.ToString();
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[3].Value = amounttotal.ToString();
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[4].Value = qtydmg.ToString();
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Cells[5].Value = dmgamount.ToString();
            }

            {
                    //View All Data of Expense_Report.........................
                    conn.Open();
                    cmd = new SqlCommand("Select Type,totalAmount from Expense1_tbl where Date between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView3.DataSource = dt;
                    conn.Close();
                }
            // Datagridview1 Total Calculation(Expense Report)......................
            {
                dataGridView3[0, dataGridView3.Rows.Count - 1].Value = "Total";
                decimal total1 = 0;
                for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
                {
                    var value = dataGridView3.Rows[i].Cells[1].Value;
                   

                    if (value != DBNull.Value)
                    {
                        total1 += Convert.ToDecimal(value);
                    }
                   
                }
                if (total1 == 0 )
                {
                }
                dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[1].Value = total1.ToString();
               
            }

            {
                //View All Data of Salesman_Report_table.........................
              

                    conn.Open();
                    cmd = new SqlCommand("Select Salesman,Units,Type from Sale_tbl where Type='12 Double yolk' or Type='12 Jumbo' or Type='12 Khaki' or Type='6 Classic' or Type='6 Double yolk' or  Type='6 Jumbo' or Type='Damage' or Type='6 Khaki' or Type='Double yolk' or  Type='Medium' or Type='Pullet' or Type='Regular' and Date between '" + dateTimePicker1.Value.ToString() + "'and'" + dateTimePicker2.Value.ToString() + "'", conn);
                
                SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    dataGridView4.DataSource = dt;
                    conn.Close();
                }
            // Datagridview1 Total Calculation(Expense Report)......................
            {
                dataGridView4[0, dataGridView4.Rows.Count - 1].Value = "Total";
               
                decimal total1 = 0;
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    var value = dataGridView4.Rows[i].Cells[1].Value;


                    if (value != DBNull.Value)
                    {
                        total1 += Convert.ToDecimal(value);
                    }

                }
                if (total1 == 0)
                {
                }
                dataGridView4.Rows[dataGridView4.Rows.Count - 1].Cells[1].Value = total1.ToString();

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExportgridtoPDF_SaleReport(dataGridView1, "Sale_tbl");
        }

        // Data Export to PDF (Sale REPORT)..................................................................
        public void ExportgridtoPDF_SaleReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);


                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Sale Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
               /*     Chunk c1 = new Chunk("|\nNet Units of Egg:   ");
                    Chunk c2 = new Chunk("|\t\tNet Discount:   ");
                    Chunk c3 = new Chunk("|\t\tNet Amount:   ");
                    Chunk c4 = new Chunk("|\t\tCash Recieve:   ");
                    Chunk c5 = new Chunk("\nTotal Balance:   ");
                    Chunk c7 = new Chunk("\nType of Egg:   ");
                    Chunk c6 = new Chunk("\nSalesman:   ");*/
                    Paragraph line4 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    pdfdoc.Open();

                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);
                    /*  pdfdoc.Add(c6);
                      pdfdoc.Add(new Phrase(this.textBox12.Text.Trim()));
                      pdfdoc.Add(c7);
                      pdfdoc.Add(new Phrase(this.textBox14.Text.Trim()));*/
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                  /*  pdfdoc.Add(c1);
                    pdfdoc.Add(new Phrase(this.textBox15.Text.Trim()));
                    pdfdoc.Add(c2);
                    pdfdoc.Add(new Phrase(this.textBox16.Text.Trim()));
                    pdfdoc.Add(c3);
                    pdfdoc.Add(new Phrase(this.textBox17.Text.Trim()));
                    pdfdoc.Add(c4);
                    pdfdoc.Add(new Phrase(this.textBox18.Text.Trim()));
                    pdfdoc.Add(c5);
                    pdfdoc.Add(new Phrase(this.textBox19.Text.Trim()));*/
                    pdfdoc.Add(line4);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }
   
        // Data Export to PDF (EXPENSE REPORT)..................................................................
        public void ExportgridtoPDF_ExpenseReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);


            PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
            pdftable.DefaultCell.Padding = 3;
            pdftable.WidthPercentage = 100;
            pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdftable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdftable.AddCell(cell);
            }

            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);

                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Expense Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph line3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                  
                    pdfdoc.Open();
                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);
                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(line3);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        // Data Export to PDF (Purchase REPORT)..................................................................
        public void ExportgridtoPDF_purReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);

            
                PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
                pdftable.DefaultCell.Padding = 3;
                pdftable.WidthPercentage = 100;
                pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdftable.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                foreach (DataGridViewColumn column in dgw.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdftable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgw.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
                var savefiledialoge = new SaveFileDialog();
                savefiledialoge.FileName = filename;
                savefiledialoge.DefaultExt = ".pdf";

                if (savefiledialoge.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                        PdfWriter.GetInstance(pdfdoc, stream);

                        Paragraph pghead = new Paragraph("EggPress Application");
                        pghead.Alignment = Element.ALIGN_CENTER;
                        pghead.Font.Size = 24;
                        Paragraph Reportname = new Paragraph("Monthly Purchase Report");
                        Reportname.Alignment = Element.ALIGN_CENTER;
                        Reportname.Font.Size = 20;
                        Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                        date.Alignment = Element.ALIGN_LEFT;
                        date.Font.Size = 16;
                        Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        Paragraph breakline = new Paragraph("\n");
                        Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                        Paragraph line3 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                        pdfdoc.Open();
                        pdfdoc.Add(pghead);
                        pdfdoc.Add(Reportname);
                        pdfdoc.Add(date);
                        pdfdoc.Add(line1);
                        pdfdoc.Add(breakline);
                        pdfdoc.Add(pdftable);
                        pdfdoc.Add(line2);
                        pdfdoc.Add(line3);
                        pdfdoc.Close();
                        stream.Close();
                    }
                } 
        }
        private void button2_Click(object sender, EventArgs e)
        {
     ExportgridtoPDF_SaleReport(dataGridView2,"Purchase2_tbl");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportgridtoPDF_ExpenseReport(dataGridView3,"Expense1_tbl");
        }

        // Data Export to PDF (Salesman REPORT)..................................................................
        public void ExportgridtoPDF_SalesmanReport(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            BaseFont bf1 = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.NOT_EMBEDDED);

         
                PdfPTable pdftable = new PdfPTable(dgw.Columns.Count);
                pdftable.DefaultCell.Padding = 3;
                pdftable.WidthPercentage = 100;
                pdftable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdftable.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);

                foreach (DataGridViewColumn column in dgw.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdftable.AddCell(cell);
                }

                foreach (DataGridViewRow row in dgw.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdftable.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
          
            var savefiledialoge = new SaveFileDialog();
            savefiledialoge.FileName = filename;
            savefiledialoge.DefaultExt = ".pdf";

            if (savefiledialoge.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefiledialoge.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0);

                    PdfWriter.GetInstance(pdfdoc, stream);


                    Paragraph pghead = new Paragraph("EggPress Application");
                    pghead.Alignment = Element.ALIGN_CENTER;
                    pghead.Font.Size = 24;
                    Paragraph Reportname = new Paragraph("Monthly Salesman Report");
                    Reportname.Alignment = Element.ALIGN_CENTER;
                    Reportname.Font.Size = 20;
                    Paragraph date = new Paragraph("\n Current Date:" + DateTime.Now.ToShortDateString());
                    date.Alignment = Element.ALIGN_LEFT;
                    date.Font.Size = 16;
                    Paragraph line1 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph breakline = new Paragraph("\n");
                    Paragraph line2 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
                    Paragraph line4 = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));

                    pdfdoc.Open();

                    pdfdoc.Add(pghead);
                    pdfdoc.Add(Reportname);
                    pdfdoc.Add(date);
                    pdfdoc.Add(line1);
                    pdfdoc.Add(breakline);

                    pdfdoc.Add(pdftable);
                    pdfdoc.Add(line2);
                    pdfdoc.Add(line4);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportgridtoPDF_SalesmanReport(dataGridView4,"Sale_tbl");
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i;
                i++;
            }
        }
    }
}
