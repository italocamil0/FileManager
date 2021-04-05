﻿using Microsoft.AspNetCore.Mvc;

namespace FileManager.App.WebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected virtual void Notify(string message, bool isError)
        {
            if (isError)
                TempData["MessageError"] = message;
            else
                TempData["Message"] = message;
        }
    }
}
