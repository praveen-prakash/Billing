using Starcounter;                                  // Most stuff relating to the database, JSON and communication is in this namespace

[Master_json]                                       // This attribute tells Starcounter that the class corresponds to an object in the JSON-by-example file.
partial class Master : Page {

    /// <summary>
    /// Every application in Starcounter works like a console application. They have an .EXE ending. They have a Main() function and
    /// they can do console output. However, they are run inside the scope of a database rather than connecting to it.
    /// </summary>
    static void Main() {
        
        // Handle.POST("/init-demo-data", () => {      // The Handle class is where you register new handlers for incomming requests.
        //     DemoData.Create();                      // Will create some demo data.
        //     return 201;                             // Returning an integer is the shortcut for returning a response with a status code.
        // });

        // Handle.GET("/master", () =>
        // {
        //     Master m = new Master()
        //     {                                       // This is the root view model for our application. A view model is a JSON object/tree.
        //         Html = "/master.html",              // This is just a field we added to allow the client to know what Html to load. No magic.
        //     };
        //     m.Session = new Session();              // Save the JSON on the server to be accessed using GET/PATCH to allow it to be used as a view model in web components.
        //     return m;                               // Return the JSON or the HTML depending on the type asked for. See Page.json on how Starcounter knowns what to return.
        // });

        // Handle.GET("/", () => {                     // The root page of our website.
        //     return PrimaryApp.GET("/primary");      // Redirecting root to Tab 1
        // });

        // Handle.GET("/primary", () =>                // The main screen of the app
        // {
        //     var m = Master.GET("/master");          // Create the view model for the main application frame.
        //     PrimaryApp p = new PrimaryApp();        // The email application also consists of a view model.
        //     p.Html = "/primary.html";               // Starcounter is a generic server and does not know of Html, so this is a variable we create in Page.json
        //     p.AddSomeNiceMenuItems(m);              // Adds some menu items in the main menu (by modifying the master view model)
        //     m.ApplicationPage = p;                  // Place the email applications view model inside the main application frame as its subpage.
        //     m.TabName = "My Form";            // Used to highlight the current tab in the client
        //     return p;                               // Returns the home page. As you can see in Page.json, we taught it how to serve both HTML and the JSON view model without any extra work.
        // });

        // Handle.GET("/primary/create", () => 
        // {
        //     var p = PrimaryApp.GET("/primary");
        //     p.FocusedPage = new PrimaryPage()
        //     {
        //         Html = "/primary-create.html"
        //     };
        //     return p;
        // });

        // Polyjuice hadlers
        // Note that all handlers could be mapped so serve content for different URLs

        // Dashboard 
        // Usually brief summary, or basic feature to be shown on a main screen.
        /*Handle.GET("/dashboard", () =>
        {
            var page = new DashboardPage()
            {
                //Html = "/dashboard.html" // will fail as other app does also use `/dashboard.html`
                Html = "/boilerplate-dashboard.html"
            };

            var ingredients = SQL<PolyjuiceBoilerplate.Ingredient>("SELECT i FROM PolyjuiceBoilerplate.Ingredient i");
            page.Ingredients.Data = ingredients;

            page.Transaction = new Transaction();
            return page;
        });*/

        // Menu
        // Launcher navigation menu
        Handle.GET("/menu", () =>
        {
            var p = new Page()
            {
                Html = "/billing-menu.html"
            };
            return p;
        });

        Handle.GET("/billing/vendables", () =>
        {
            var page = new VentablesPage()
            {
                Html = "/billing-vendables.html"
            };
            page.Transaction = new Transaction();
            page.Session = Session.Current;

            var vendables = SQL<Billing.Vendable>("SELECT v FROM Billing.Vendable v");
            page.Vendables.Data = vendables;

            return page;
        });

        Handle.GET("/billing/offers", () =>
        {
            var page = new OffersPage()
            {
                Html = "/billing-offers.html"
            };
            page.Transaction = new Transaction();
            page.Session = Session.Current;

            var offers = SQL<Billing.Offer>("SELECT o FROM Billing.Offer o");
            page.Offers.Data = offers;

            var vendables = SQL<Billing.Vendable>("SELECT v FROM Billing.Vendable v");
            page.Vendables.Data = vendables;

            return page;
        });

        Handle.GET("/billing/buy", () =>
        {
            var page = new BuyPage()
            {
                Html = "/billing-buy.html"
            };
            page.Transaction = new Transaction();
            page.Session = Session.Current;

            var offers = SQL<Billing.Offer>("SELECT o FROM Billing.Offer o");
            page.Offers.Data = offers;

            return page;
        });
    }
}




