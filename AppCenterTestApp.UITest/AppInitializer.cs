﻿using AppCenterTestApp.UITest.UITestHelpers;
using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace AppCenterTestApp.UITest
{
	public class AppInitializer
	{
		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				return ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    //.ApkFile(@"C:\Users\Sylvain\AppData\Local\Xamarin\Mono for Android\Archives\fr.sylvainmoingeon.appcentertestapp.apk")
                    .InstalledApp("fr.sylvainmoingeon.appcentertestapp")
                    .WaitTimes(new WaitTimes())
                    .StartApp();
			}

			return ConfigureApp
                .iOS
                .EnableLocalScreenshots()                
                .StartApp();
		}
	}
}