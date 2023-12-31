﻿using AgriculturePresentation.Models___Copy;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AgriculturePresentation.Controllers___Copy
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workBook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workBook.Cells[1, 1].Value = "Ürün Adı";
            workBook.Cells[1, 2].Value = "Ürün Kategorisi";
            workBook.Cells[1, 3].Value = "Ürün Stok";

            workBook.Cells[2, 1].Value = "Mercimek";
            workBook.Cells[2, 2].Value = "Bakliyat";
            workBook.Cells[2, 3].Value = "785 kg";

            workBook.Cells[3, 1].Value = "Buğday";
            workBook.Cells[3, 2].Value = "Bakliyat";
            workBook.Cells[3, 3].Value = "1,986 kg";

            workBook.Cells[4, 1].Value = "Havuç";
            workBook.Cells[4, 2].Value = "Sebze";
            workBook.Cells[4, 3].Value = "167 kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Bakliyat Raporu.xlsx");
        }


        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.Name,
                    ContactDate = x.Date,
                    ContactMail = x.Mail,
                    ContactMessage = x.Message
                }).ToList();
            }
            return contactModels;
        }

        public IActionResult MessageReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Gönderen";
                workSheet.Cell(1, 3).Value = "Mail Adresi";
                workSheet.Cell(1, 4).Value = "İçerik";
                workSheet.Cell(1, 5).Value = "Tarih";

                int contactRowCount = 2;
                foreach (var x in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = x.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = x.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = x.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = x.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = x.ContactDate;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }
            }
        }

        public List<AnnouncementModel> announcementList()
        {
            List<AnnouncementModel> models = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                models = context.Announcements.Select(x => new AnnouncementModel
                {
                    AnnouncemenetID = x.AnnouncementID,
                    AnnouncemenetTitle = x.Title,
                    AnnouncemenetDescription = x.Description,
                    AnnouncemenetDate = x.Date,
                    AnnouncemenetStatus = x.Status
                }).ToList();
            }
            return models;
        }

        public IActionResult DuyuruReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Başlık";
                workSheet.Cell(1, 3).Value = "İçerik";
                workSheet.Cell(1, 4).Value = "Tarih";
                workSheet.Cell(1, 5).Value = "Durum";

                int contactRowCount = 2;
                foreach (var x in announcementList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = x.AnnouncemenetID;
                    workSheet.Cell(contactRowCount, 2).Value = x.AnnouncemenetTitle;
                    workSheet.Cell(contactRowCount, 3).Value = x.AnnouncemenetDescription;
                    workSheet.Cell(contactRowCount, 4).Value = x.AnnouncemenetDate;
                    workSheet.Cell(contactRowCount, 5).Value = x.AnnouncemenetStatus;
                    contactRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
                }
            }
        }
    }
}
