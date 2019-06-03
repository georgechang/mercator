# Mercator 🗺

[![Build Status](https://dev.azure.com/georgechang/Mercator/_apis/build/status/georgechang.mercator?branchName=master)](https://dev.azure.com/georgechang/Mercator/_build/latest?definitionId=6&branchName=master)

A simple and lightweight mapper for Sitecore.

You might be asking yourself, wait, **another** ORM for Sitecore? Why?

¯\\\_(ツ)\_/¯

### Okay, I'll bite. What's so special about this one?

* it's tiny (< 8k) - just one DLL, no config files
* it uses the existing Sitecore API - no new classes or types
* I wrote it

### Not compelling enough. Show me some code.

#### Controller
```csharp
public class DemoController : Controller
{
	public ActionResult Component()
	{
		var componentViewModel = RenderingContext.Current.Rendering.Item.Map<ComponentViewModel>();
		componentViewModel.SomeOtherNonSitecoreContent = "Hello nurse!";
		return View(componentViewModel);
	}
}
```

#### View Model
```csharp
public class ComponentViewModel
{
	// map by field name
	[SitecoreField("Title")]
	// use your friendly neighborhood Sitecore field types
	public TextField Title { get; set; }

	[SitecoreField("Description")]
	public HtmlField Description { get; set; }

	[SitecoreField("Image")]
	public ImageField Image { get; set; }

	[SitecoreField("Link")]
	public LinkField Link { get; set; }

	// or by field ID
	[SitecoreField("{ABDECD77-1C41-406C-82E1-3A9ED4050115}")]
	public CheckboxField Checkbox { get; set; }

	[SitecoreField("{0E5015AE-2D95-4500-A723-91CC723A5AE7}")]
	public LookupField Droplink { get; set; }

	// or nothing at all if it's not coming from Sitecore
	public string SomeOtherNonSitecoreContent { get; set; }
}
```

#### View
```html
@model ComponentViewModel

<div>
	<!-- You can specify the model... -->
	<h1>@Html.Mercator().Field(Model, x => x.Title)</h1>
	<p>@Html.Mercator().Field(Model, x => x.Description)</p>

	<!-- ...or you can let it infer from the @@Model declaration -->
	@Html.Mercator().Field(x => x.Image)
	@Html.Mercator().Field(x => x.Link)
	
	<!-- MVC helpers work since the field types return simple types -->
	@Html.CheckBox("checkbox", Model.Checkbox.Checked)
	
	<!-- Normal Sitecore field types using the normal Sitecore API -->
	@Model.Droplink.TargetItem.Name
	
	<!-- This is populated from the controller, not from Sitecore -->
	<h4>@Model.SomeOtherNonSitecoreContent</h4>
</div>
```

### What is this `@Html.Mercator().Field()` business? I thought you said there was no API!

It's a helper. 😀 Think of it as a wrapper for `FieldRenderer.Render()`. It determines the appropriate field from the `[SitecoreField]` attribute and calls `FieldRenderer.Render()` for that field. No fuss, no muss.