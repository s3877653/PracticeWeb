using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace RazorLoginPage.Pages
{
	public class HomePageRouteModelConvention : IPageRouteModelConvention
	{
		public void Apply(PageRouteModel model)
		{
			if (model.RelativePath == "/Pages/Index.cshtml")
			{
				var currentHomePage = model.Selectors.Single(s => s.AttributeRouteModel.Template == string.Empty);
				model.Selectors.Remove(currentHomePage);
			}

			if (model.RelativePath == "/Pages/HomePage/Index.cshtml")
			{
				model.Selectors.Add(new SelectorModel()
				{
					AttributeRouteModel = new AttributeRouteModel
					{
						Template = string.Empty
					}
				});
			}
		}
	}
}
