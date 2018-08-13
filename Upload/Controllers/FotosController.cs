using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upload.Models;

namespace Upload.Controllers
{
    public class FotosController : Controller
    {
        FotoContext db = new FotoContext();

        // GET: Fotos
        public ActionResult CadastrarFoto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarFoto(HttpPostedFileBase file)
        {
            FotoViewModel fotoModel = new FotoViewModel();

            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/images"), pic);
                // file is uploaded
                //file.SaveAs(path);

                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(array);
                    fotoModel.Base64 = base64String;
                }

                //Prepara Foto
                string imagem_base64 = fotoModel.Base64.Replace("data:image/png;base64,", "");
                imagem_base64 = imagem_base64.Replace("data:image/jpeg;base64,", "");
                imagem_base64 = imagem_base64.Replace("data:image/pdf;base64,", "");

                Foto foto = new Foto();
                foto.Binario = Convert.FromBase64String(imagem_base64);

                db.Fotos.Add(foto);
                db.SaveChanges();
                
            }
            return View();
        }

        // GET: Produtos
        [HttpGet]
        public ActionResult ListaFotos()
        {
            var produtos = db.Fotos.ToList();


            return View(produtos);
        }
    }
}