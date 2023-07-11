
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SviyajskMonitorSystem.Data;
using SviyajskMonitorSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using SviyajskMonitorSystem.Services;
using SviyajskMonitorSystem.Models.OptionModels;
using Microsoft.Extensions.Options;
using SviyajskMonitorSystem.Models.AccountViewModels;

namespace SviyajskMonitorSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
   
        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext _context,IEmailSender sender)
        {
            context = _context;
            _userManager = userManager;
            _emailSender = sender;
        }



        public async Task<IActionResult> Index()
        {

            List<UserViewModel> users = new List<UserViewModel>();
            foreach(ApplicationUser us in _userManager.Users)
            {
                users.Add(await ConvertUser(us));
            }

            ViewData["Users"] = users;
            ViewData["Requests"] = context.AccauntReqest.AsEnumerable();
            return View("Index");
        }

        //converts user to put data in view
        [NonAction]
        private async Task<UserViewModel> ConvertUser(ApplicationUser us)
        {
            UserViewModel userview = new UserViewModel();
            userview.Id = us.Id;
            userview.name = us.name;
            userview.surname = us.surname;
            userview.phone = us.PhoneNumber;
            userview.email = us.Email;
            userview.isresearcher = await _userManager.IsInRoleAsync(us, "Researcher");
            userview.isadmin =await _userManager.IsInRoleAsync(us, "Admin");
            return userview;
        }



        public async Task<IActionResult> Register(int? id)
        {
            AccauntRequestData data = await context.AccauntReqest.FirstAsync(ar => ar.id == id);
            ApplicationUser user = new ApplicationUser();
            user.name = data.name;
            user.PhoneNumber = data.phone;
            user.surname = data.surname;
            user.Email = data.email;
            user.UserName = data.email;
            string password = LowLevelHelper.GeneratePassword(12);
            var result=await _userManager.CreateAsync(user,password );
            if (result.Succeeded)
            {
                context.AccauntReqest.Remove(data);
                await context.SaveChangesAsync();
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code, password=password }, protocol: HttpContext.Request.Scheme);
                await _emailSender.SendEmailAsync(user.Email, "Ваша заявка принята", $"Вам создан аккаунт в системе. Логин:{user.Email}, пароль:{password}. Пожалуйста подтвердите регистрацию перейдя по ссылке <a href='{callbackUrl}' >Подтвердить регистрацию</a>");
            }
            return RedirectToAction("Index");
        }

        //sets user admin


        public async Task<IActionResult> MakeAdmin(string id)
        {
            ApplicationUser us =await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(us, "Admin");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MakeResearcher(string id)
        {
            ApplicationUser us = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(us, "Researcher");
            return RedirectToAction("Index");
        }

    }
}
