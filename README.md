# IgniteCaptcha
IgniteCaptcha is a library for creating captcha for .Net Core 2.0 projects quickly and simply.

|Package Name | NuGet line command |
|-------------|--------------------|
|IgniteCaptcha |Install-Package IgniteCaptcha -Version 1.0.0|


For you can use the library, you have to create a folder on your file system, and map it as example in the box below in method Configure at Startup.cs file.

	app.UseStaticFiles(new StaticFileOptions(){
		FileProvider = new PhysicalFileProvider(
			Path.Combine(Directory.GetCurrentDirectory(), @"output")),
			RequestPath = new PathString("/captcha")
		});

Next step is source example for generate the captcha, that example use the session for save the captcha value for compare the value, but there are different ways for this. I recommends you read the oficcial documents about session and application state in ASP.NET Core and chosse the best way for your application.

Should you write in your controller a source code with the same look you can see box below.


	public ActionResult Index(){
		string cptvalue = null;
		ViewData["captcha"] = IgniteCaptcha.GenCaptcha(
			Path.Combine(Directory.GetCurrentDirectory(), @"output"), 300, 150, out cptvalue);
		HttpContext.Session.SetString("CaptchaValue", cptvalue);
		return View();
	}
				
In your view file, you can write a HTML as the box below to can see the image captcha.
			
			<img src="~/captcha/@ViewData["captcha"]" />

The project IgniteCaptchaSample is a simple example how you can use that library.

References:

Introduction to session and application state in ASP.NET Core.

https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?tabs=aspnetcore2x
