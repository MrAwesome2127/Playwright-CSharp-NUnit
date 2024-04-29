﻿using Playwright_Automation_Framework.Driver;

namespace PlayWrightCSharp.Pages;

public interface IProduct_Page
{
    Task AddToCart_PhysicalCopy(string product_name);
}

public class Product_Page : IProduct_Page
{
    private readonly IPage _page;

    public Product_Page(IPlaywrightDriver playwrightDriver)
    {
        _page = playwrightDriver.Page.Result;
    }

    #region Locators
    private ILocator _btnAddToCart => _page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" });
    #endregion

    public async Task AddToCart_PhysicalCopy(string product_name)
    {
        await _page.GetByText("Physical" + product_name, new() { Exact = true }).ClickAsync();
        await _page.WaitForSelectorAsync("Add to cart");
        await Assertions.Expect(_btnAddToCart).ToBeVisibleAsync();
        await _btnAddToCart.ClickAsync();
    }
}