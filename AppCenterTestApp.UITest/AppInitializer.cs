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
                    .ApkFile(@"../../../AndroidApks/fr.sylvainmoingeon.appcentertestapp.apk")
                    .StartApp();
			}

			return ConfigureApp.iOS.StartApp();
		}
	}
}