using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarWashAggregator.Notifications.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarWashAggregator.Notifications.Deamon.Controllers
{
    public class TestController : Controller
    {
        private readonly INotificationService _notificationService;

        public TestController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<JsonResult> GetAllNotifications()
        {
            return Json(await _notificationService.GetAllNotifications());
        }
    }
}
