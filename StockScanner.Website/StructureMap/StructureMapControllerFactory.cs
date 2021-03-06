﻿using System;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace StockScanner.Website.StructureMap
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null) return null;

            try
            {
                return ObjectFactory.GetInstance(controllerType) as Controller;
            }

            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());

                throw;
            }
        }
    }
}