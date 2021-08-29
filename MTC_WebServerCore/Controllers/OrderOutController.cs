using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MTC_WebServerCore.Bussiness;
using MTCmailServer;
using MTCmodel;
using MTCrepository.DTO;
using MTCrepository.TDSrepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MTC_WebServerCore.Controllers
{
    public class OrderOutController : Controller
    {
        private readonly ILogger<OrderOutController> _logger;
        private readonly IApplicationRepository _repos;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderOutController(ILogger<OrderOutController> logger, IApplicationRepository appRepos, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _repos = appRepos;
            _userManager = userManager;
        }



        #region ========================================================================================================================================== Reserved to prepared
        [Authorize(Policy = "PreparingOrderOUT")]
        [HttpGet]
        public async Task<IActionResult> OverviewReservedToPrepared()
        {
            //get all existing categories
            var model = await _repos.OrderOUTs.getOrderOutDTO(StatusOfOrder.Reserved, true);
            return View(model);
        }

        //------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "PreparingOrderOUT")]
        public async Task<IActionResult> OverviewReservedToPrepared([FromForm] OrderOutOverview_DTO model)
        {

            //first we check if combobox Transporter is setted on rows where checkbox is checked
            for (int i = 0; i < model.OrderOutOverviewItems.Count; i++)
            {
                if (model.OrderOutOverviewItems[i].IsChecked && model.OrderOutOverviewItems[i].TransporterId == null)
                {
                    ModelState.AddModelError($"OrderOutOverviewItems[{i}].TransporterId", "checked items must be a Transporter");
                }
            }


            if (!ModelState.IsValid)
            {
                return View(model);
            }


            foreach (var item in model.OrderOutOverviewItems)
            {
                if (item.IsChecked)
                {
                    var xxx = await _repos.OrderOUTs.GetById_withOrderlineOut_Async(item.OrderOutId);
                    (xxx.Data).Status = StatusOfOrder.Preparing;

                    foreach (var oolo in (xxx.Data).OrderLineOUTs.ToList())
                    {
                        oolo.TransporterId = item.TransporterId;
                    }

                    await _repos.OrderOUTs.UpdateAsync(xxx.Data);


                    #region                        ==========================================email verzenden
                    StringBuilder sbBody = new StringBuilder();

                    sbBody.Append("<hr>");
                    sbBody.Append($"<h3>Beste {item.FullNameOfClient}</h3>");
                    sbBody.Append($"<p>Uw order met nummer {item.OrderOutId.ConvertToInvoice()} is in gereedheid gebracht om verzonden te worden </p>");
                    sbBody.Append($"<p>Vriendelijke groeten </p>");
                    sbBody.Append($"<p>MTC Belgie </p>");

                    sbBody.Append("<hr>");


                    MTCmail mail = new MTCmail(item.EmailClient, "Order status gewijzigd naar klaargemaakt", sbBody.ToString());

                    var emailResult = await mail.SendHtmlAsync();
                    #endregion
                }
            }

            return RedirectToAction(nameof(OverviewReservedToPrepared));

        }

        #endregion



        #region ================================================================================================================================================== prepared to send
        [HttpGet]
        [Authorize(Policy = "PreparingOrderOUT")]
        public async Task<IActionResult> OverviewPreparedToSent()
        {
            //get all existing categories
            var model = await _repos.OrderOUTs.getOrderOutDTO(StatusOfOrder.Preparing);
            return View(model);
        }

        //------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "PreparingOrderOUT")]
        public async Task<IActionResult> OverviewPreparedToSent([FromForm] OrderOutOverview_DTO model)
        {

            foreach (var item in model.OrderOutOverviewItems)
            {
                if (item.IsChecked)
                {
                    var xxx = await _repos.OrderOUTs.GetByIdAsync(item.OrderOutId);
                    (xxx.Data).Status = StatusOfOrder.Sent;
                    await _repos.OrderOUTs.UpdateAsync(xxx.Data);


                    //--------------------------------------------------------------------------email verzenden
                    StringBuilder sbBody = new StringBuilder();

                    sbBody.Append("<hr>");
                    sbBody.Append($"<h3>Beste {item.FullNameOfClient}</h3>");
                    sbBody.Append($"<p>Uw order met nummer {item.OrderOutId.ConvertToInvoice()} is verzonden. </p> ");
                    sbBody.Append($"<p>De levering zal zo snel mogelijk bezorgd worden door {item.TransporterName}. </p>");

                    sbBody.Append($"<p>Vriendelijke groeten </p>");
                    sbBody.Append($"<p>MTC Belgie </p>");

                    sbBody.Append("<hr>");


                    MTCmail mail = new MTCmail(item.EmailClient, "Order status gewijzigd naar Verzonden", sbBody.ToString());
                    var emailResult = await mail.SendHtmlAsync();

                }
            }

            return RedirectToAction(nameof(OverviewPreparedToSent));
        }

        #endregion



        #region ================================================================================================================================================== sent to delivered
        [HttpGet]

        [Authorize(Roles = "Transporter")]
        public async Task<IActionResult> OverviewSentToDelivered()
        {
            //get all existing categories
            var model = await _repos.OrderOUTs.getOrderOutDTO(StatusOfOrder.Sent);
            return View(model);
        }

        //------------------------------------------------------------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "PreparingOrderOUT")]
        public async Task<IActionResult> OverviewSentToDelivered([FromForm] OrderOutOverview_DTO model)
        {
            Thread.Sleep(5000);
            foreach (var item in model.OrderOutOverviewItems)
            {
                if (item.IsChecked)
                {
                    var xxx = await _repos.OrderOUTs.GetByIdAsync(item.OrderOutId);
                    (xxx.Data).Status = StatusOfOrder.Delivered;
                    await _repos.OrderOUTs.UpdateAsync(xxx.Data);


                    //--------------------------------------------------------------------------email verzenden
                    StringBuilder sbBody = new StringBuilder();

                    sbBody.Append("<hr>");
                    sbBody.Append($"<h3>Beste {item.FullNameOfClient}</h3>");
                    sbBody.Append($"<p>Uw order met nummer {item.OrderOutId.ConvertToInvoice()} is geleverd door de transportfirma {item.TransporterName}. </p> ");
                    sbBody.Append($"<p>MTC wenst je veel genot de aangekochte goederen. </p>");

                    sbBody.Append($"<p>Vriendelijke groeten </p>");
                    sbBody.Append($"<p>MTC Belgie </p>");

                    sbBody.Append("<hr>");


                    MTCmail mail = new MTCmail(item.EmailClient, "Order status gewijzigd naar geleverd", sbBody.ToString());
                    var emailResult = await mail.SendHtmlAsync();

                }
            }

            return RedirectToAction(nameof(OverviewSentToDelivered));
        }

        #endregion


    }
}