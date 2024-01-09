using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Models;
using SendEmail.Services;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmailWithMailKit()
        {
            try
            {
                EmailDTO emailDto = new EmailDTO();
                emailDto.To = "lammjnhphong4560@gmail.com";
                emailDto.Subject = "Test send emai";
                emailDto.Body = GetHtmlcontent();
                await _emailService.SendEmail(emailDto);
                return Ok(emailDto);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private string GetHtmlcontent()
        {
            string Response = "<div style=\"width:100%;background-color:lightblue;text-align:center;margin:10px\">";
            Response += "<h1>Welcome to Nguyen Duc Minh</h1>";
            Response += "<img style=\"width:30rem\" src=\"https://mail.google.com/mail/u/1?ui=2&ik=83c82e28c5&attid=0.1&permmsgid=msg-f:1781508469062131439&th=18b9308386cc5eef&view=fimg&fur=ip&sz=s0-l75-ft&attbid=ANGjdJ91RgZR8qYEu6CYlyzqIWItCO2en8cyBZV5p8yhnEXTC7Lhm-nsbPVTTzAmflEeVXmZoW6fuopXWIDpVNgIKL2PmHU0Mo0xttIHvdp0RAysfJttrHcLGxcCiuU&disp=emb\" />";
            Response += "<h2 style=\"text-color:red\">Dear Nguyễn Phạm Quốc Thắng</h2>";
            Response += "<a href=\"https://www.facebook.com/Devboygalaxy\">Please join group by click the link</a>";
            Response += "<div><h1> Contact us : lammjnhphong4560@gmail.com</h1></div>";
            Response += "</div>";
            return Response;
        }
    }
}
