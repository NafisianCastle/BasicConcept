using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.IO;
using System.Net.Mail;

namespace PDFExtraction
{
    internal class ModifyPdf : System.Web.UI.Page
    {
        public string P_InputStream = "~/MyPDFTemplates/ex1.pdf";
        public string P_InputStream2 = "~/MyPDFTemplates/ContactInfo.pdf";
        public string P_InputStream3 = "~/MyPDFTemplates/MulPages.pdf";
        public string P_InputStream4 = "~/MyPDFTemplates/CompanyLetterHead.pdf";
        public string P_OutputStream = "~/MyPDFOutputs/ex1_1.pdf";
        //Read all 'Form values/keys' from an existing multi-page PDF document
        public void ReadPDFformDataPageWise()
        {
            var reader = new PdfReader(Server.MapPath(P_InputStream3));
            var form = reader.AcroFields;
            try
            {
                for (var page = 1; page <= reader.NumberOfPages; page++)
                {
                    foreach (var kvp in form.Fields)
                    {
                        switch (form.GetFieldType(kvp.Key))
                        {
                            case AcroFields.FIELD_TYPE_CHECKBOX:
                            case AcroFields.FIELD_TYPE_COMBO:
                            case AcroFields.FIELD_TYPE_LIST:
                            case AcroFields.FIELD_TYPE_RADIOBUTTON:
                            case AcroFields.FIELD_TYPE_NONE:
                            case AcroFields.FIELD_TYPE_PUSHBUTTON:
                            case AcroFields.FIELD_TYPE_SIGNATURE:
                            case AcroFields.FIELD_TYPE_TEXT:
                                var fileType = form.GetFieldType(kvp.Key);
                                var fieldValue = form.GetField(kvp.Key);
                                var translatedFileName = form.GetTranslatedFieldName(kvp.Key);
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
        }

        //Read and alter form values for only second and 
        //third page of an existing multi page PDF doc.
        //Save the changes in a brand new pdf file.
        public void ReadAlterPDFformDataInSelectedPages()
        {
            var reader = new PdfReader(Server.MapPath(P_InputStream3));
            reader.SelectPages("1-2"); //Work with only page# 1 & 2
            using (var stamper = new PdfStamper(reader, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
            {
                var form = stamper.AcroFields;
                var fieldKeys = form.Fields.Keys;
                foreach (var fieldKey in fieldKeys)
                {
                    //Replace Address Form field with my custom data
                    if (fieldKey.Contains("Address"))
                    {
                        form.SetField(fieldKey, "MyCustomAddress");
                    }
                }
                //The below will make sure the fields are not editable in
                //the output PDF.
                stamper.FormFlattening = true;
            }
        }

        //Extract text from an existing PDF's second page.
        private string ExtractText()
        {
            var reader = new PdfReader(Server.MapPath(P_InputStream3));
            var txt = PdfTextExtractor.GetTextFromPage(reader, 2, new LocationTextExtractionStrategy());
            return txt;
        }


        //Create a brand new PDF from scratch and without a template
        private void CreatePDFNoTemplate()
        {
            var pdfDoc = new Document();
            var writer = PdfWriter.GetInstance(pdfDoc, new FileStream(Server.MapPath(P_OutputStream), FileMode.OpenOrCreate));

            pdfDoc.Open();
            pdfDoc.Add(new Paragraph("Some data"));
            var cb = writer.DirectContent;
            cb.MoveTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height / 2);
            cb.LineTo(pdfDoc.PageSize.Width / 2, pdfDoc.PageSize.Height);
            cb.Stroke();

            pdfDoc.Close();
        }

        private void fillPDFForm()
        {
            var formFile = Server.MapPath(P_InputStream);
            var newFile = Server.MapPath(P_OutputStream);
            var reader = new PdfReader(formFile);
            using (var stamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create)))
            {
                var fields = stamper.AcroFields;

                // set form fields
                fields.SetField("name", "John Doe");
                fields.SetField("address", "xxxxx, yyyy");
                fields.SetField("postal_code", "12345");
                fields.SetField("email", "johndoe@xxx.com");

                // flatten form fields and close document
                stamper.FormFlattening = true;
                stamper.Close();
            }
        }

        //Helper functions
        private void SendEmail(MemoryStream ms)
        {
            var _From = new MailAddress("XXX@domain.com");
            var _To = new MailAddress("YYY@a.com");
            var email = new MailMessage(_From, _To);
            var attach = new Attachment(ms, new System.Net.Mime.ContentType("application/pdf"));
            email.Attachments.Add(attach);
            var mailSender = new SmtpClient("Gmail-Server");
            mailSender.Send(email);
        }

        private void DownloadAsPDF(MemoryStream ms)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment;filename=abc.pdf");
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.OutputStream.Close();
            Response.End();
            ms.Close();
        }

        //Working with Memory Stream and PDF
        public void CreatePDFFromMemoryStream()
        {
            //(1)using PDFWriter
            var doc = new Document();
            var memoryStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(doc, memoryStream);
            doc.Open();
            doc.Add(new Paragraph("Some Text"));
            writer.CloseStream = false;
            doc.Close();
            //Get the pointer to the beginning of the stream. 
            memoryStream.Position = 0;
            //You may use this PDF in memorystream to send as an attachment in an email
            //OR download as a PDF
            SendEmail(memoryStream);
            DownloadAsPDF(memoryStream);

            //(2)Another way using PdfStamper
            var reader = new PdfReader(Server.MapPath(P_InputStream2));
            using (var ms = new MemoryStream())
            {
                var stamper = new PdfStamper(reader, ms);
                var fields = stamper.AcroFields;
                fields.SetField("SomeField", "MyValueFromDB");
                stamper.FormFlattening = true;
                stamper.Close();
                SendEmail(ms);
            }
        }

        //Burst-- Make each page of an existing multi-page PDF document 
        //as another brand new PDF document
        private void PDFBurst()
        {
            var pdfTemplatePath = Server.MapPath(P_InputStream3);
            var reader = new PdfReader(pdfTemplatePath);
            //PdfCopy copy;
            PdfSmartCopy copy;
            for (var i = 1; i < reader.NumberOfPages; i++)
            {
                var d1 = new Document();
                copy = new PdfSmartCopy(d1, new FileStream(Server.MapPath(P_OutputStream).Replace(".pdf", i.ToString() + ".pdf"), FileMode.Create));
                d1.Open();
                copy.AddPage(copy.GetImportedPage(reader, i));
                d1.Close();
            }
        }

        //Copy a set of form fields from an existing PDF template/doc
        //and keep appending to a brand new PDF file.
        //The copied set of fields will have different values.
        private void AppendSetOfFormFields()
        {
            var _copy = new PdfCopyFields(new FileStream(Server.MapPath(P_OutputStream), FileMode.Create));
            _copy.AddDocument(new PdfReader(a1("1")));
            _copy.AddDocument(new PdfReader(a1("2")));
            _copy.AddDocument(new PdfReader(new FileStream(Server.MapPath("~/MyPDFTemplates/Myaspx.pdf"), FileMode.Open)));
            _copy.Close();
        }
        //ConcatenateForms
        private byte[] a1(string _ToAppend)
        {
            using (var existingFileStream = new FileStream(Server.MapPath(P_InputStream), FileMode.Open))
            using (var stream = new MemoryStream())
            {
                // Open existing PDF
                var pdfReader = new PdfReader(existingFileStream);
                var stamper = new PdfStamper(pdfReader, stream);
                var form = stamper.AcroFields;
                var fieldKeys = form.Fields.Keys;

                foreach (var fieldKey in fieldKeys)
                {
                    form.RenameField(fieldKey, fieldKey + _ToAppend);
                }
                // "Flatten" the form so it wont be editable/usable anymore
                stamper.FormFlattening = true;
                stamper.Close();
                pdfReader.Close();
                return stream.ToArray();
            }
        }


        //Working with Image
        private void AddAnImage()
        {
            using (var inputPdfStream = new FileStream(@"C:\MyInput.pdf", FileMode.Open))
            using (var inputImageStream = new FileStream(@"C:\img1.jpg", FileMode.Open))
            using (var outputPdfStream = new FileStream(@"C:\MyOutput.pdf", FileMode.Create))
            {
                var reader = new PdfReader(inputPdfStream);
                var stamper = new PdfStamper(reader, outputPdfStream);
                var pdfContentByte = stamper.GetOverContent(1);
                var image = iTextSharp.text.Image.GetInstance(inputImageStream);
                image.SetAbsolutePosition(1, 1);
                pdfContentByte.AddImage(image);
                stamper.Close();
            }

        }


        //Add Company Letter-Head/Stationary to an existing pdf
        private void AddCompanyStationary()
        {
            var reader = new PdfReader(Server.MapPath(P_InputStream2));
            var s_reader = new PdfReader(Server.MapPath(P_InputStream4));

            using (var stamper = new PdfStamper(reader, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
            {
                var page = stamper.GetImportedPage(s_reader, 1);
                var n = reader.NumberOfPages;
                PdfContentByte background;
                for (var i = 1; i <= n; i++)
                {
                    background = stamper.GetUnderContent(i);
                    background.AddTemplate(page, 0, 0);
                }
                stamper.Close();
            }
        }


        //Create a new PDF document by copying only 2nd page from an existing PDF document.
        //Also add a date on the top-left corner.
        private void AddText()
        {
            //Method 1:
            var reader = new PdfReader(Server.MapPath(P_InputStream3));
            using (var document = new Document())
            {
                using (var writer = PdfWriter.GetInstance(document, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
                {
                    document.Open();
                    var cb = writer.DirectContent;
                    var page = writer.GetImportedPage(reader, 2);

                    document.NewPage();
                    cb.AddTemplate(page, 0, 0);
                    document.Add(new Paragraph(DateTime.Now.ToShortDateString()));
                    document.Close();
                }
            }
            //Method 2:
            var reader2 = new PdfReader(Server.MapPath(P_InputStream3));
            using (var stamper = new PdfStamper(reader, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
            {
                stamper.RotateContents = false;
                var canvas = stamper.GetOverContent(2);
                ColumnText.ShowTextAligned(canvas, Element.ALIGN_LEFT, new Phrase(DateTime.Now.ToShortDateString()), 0, 0, 0);
                stamper.Close();
            }
        }


        //DataSheets: Copy 2 pages from one PDF to another brand new PDF.
        //Also alter some form data
        private void CreatePDFByCopy()
        {
            using (var document = new Document())
            {
                using (var copy = new PdfSmartCopy(document, new FileStream(Server.MapPath(P_OutputStream), FileMode.Create)))
                {
                    document.Open();
                    for (var i = 0; i < 2; ++i)
                    {
                        var reader = new PdfReader(AddDataSheets("Some Text" + i.ToString()));
                        copy.AddPage(copy.GetImportedPage(reader, 1));
                    }
                }
            }
        }
        public byte[] AddDataSheets(string _data)
        {
            var pdfTemplatePath = Server.MapPath(P_InputStream2);
            var reader = new PdfReader(pdfTemplatePath);
            using (var ms = new MemoryStream())
            {
                using (var stamper = new PdfStamper(reader, ms))
                {
                    var form = stamper.AcroFields;
                    var fieldKeys = form.Fields.Keys;
                    foreach (var fieldKey in fieldKeys)
                    {
                        //Change some data
                        if (fieldKey.Contains("Address"))
                        {
                            form.SetField(fieldKey, _data);
                        }
                    }
                    stamper.FormFlattening = true;
                }
                return ms.ToArray();
            }
        }
    }
}
