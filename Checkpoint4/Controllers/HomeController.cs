using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Checkpoint4.Models;
using Checkpoint4.DAL;
using System.Web.Security;

// Group 2-4: Alyssa Anderson, Nate Bezzant, Rowan Cutler, Kyle Waters
namespace Checkpoint4.Controllers
{
    public class HomeController : Controller

    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String username = form["Username"].ToString();
            String password = form["Password"].ToString();

            if (string.Equals(username, "Missouri") && (string.Equals(password, "ShowMe")))
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }



        private BlowOutContext db = new BlowOutContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Support = "Please call Support at <b><u>801-555-1212</u></b>. Thank you!"; ;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(EmailFormModel model)
        {

            if (ModelState.IsValid)
            {
                var senderEmail = new MailAddress("rankIS403@gmail.com", "werenumber1");
                var receiverEmail = new MailAddress("rankIS403@gmail.com", "Receiver");
                var password = "werenumber1";
                var body = model.Message.ToString();
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "From RANK",
                    Body = "Customer's email: " + model.FromEmail + "\n" + "Message: " + body
                })
                {
                    smtp.Send(mess);
                }

            }
            return RedirectToAction("Email", new { email = "rankIS403@gmail.com", name = model.FromName });
        }

        public ActionResult Email(string email, string name)
        {
            ViewBag.Thanks = name + " we will send an email to " + email + ".";
            return View();
        }



        public ActionResult Rentals()
        {
            
            return View(db.Instruments.ToList());
        }

        // GET: Clients/Create
        public ActionResult Create(int ID)
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Client_ID,First_Name,Last_Name,Street_Address,City,State,Zip,Email,Phone")] Client client, int ID)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();

                //look up instrument
                Instrument myInstrument = db.Instruments.Find(ID);
                //update instrument
                myInstrument.Client_ID = client.Client_ID;
                //save changes
                db.SaveChanges();
                return RedirectToAction("Summary", new { Client_ID = client.Client_ID, Instrument_ID = myInstrument.Instrument_ID});
            }

            return View(client);
        }

        public ActionResult Summary(int Client_ID, int Instrument_ID)
        {
            Client myClient = db.Clients.Find(Client_ID);
            Instrument myInstrument = db.Instruments.Find(Instrument_ID);

            ViewBag.Client = myClient.First_Name + ' ' + myClient.Last_Name;
            ViewBag.Instrument = myInstrument.Desc;
            ViewBag.OrderID = myClient.Client_ID;
            ViewBag.Type = myInstrument.Type;
            ViewBag.Price = myInstrument.Price;
            ViewBag.TotalPrice = myInstrument.Price * 18;
            ViewBag.Image = myInstrument.Desc + ".jpg";
            //total amount after 18 months
            //image
            return View();
        }
    }
}