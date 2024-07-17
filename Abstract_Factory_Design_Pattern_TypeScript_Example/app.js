var Page = /** @class */ (function () {
    function Page() {
    }
    return Page;
}());
// Concrete Product
var Header = /** @class */ (function () {
    function Header(text) {
        console.log(text);
    }
    return Header;
}());
// Concrete Product
var Body = /** @class */ (function () {
    function Body(text) {
        console.log(text);
    }
    return Body;
}());
// Concrete Product
var Footer = /** @class */ (function () {
    function Footer(text) {
        console.log(text);
    }
    return Footer;
}());
// Concrete Factory
var HomePageFactory = /** @class */ (function () {
    function HomePageFactory() {
    }
    HomePageFactory.prototype.createHeader = function () {
        return new Header("Home sayfasi icin header olusturuldu");
    };
    HomePageFactory.prototype.createBody = function () {
        return new Body("Home sayfasi icin body olusturuldu");
    };
    HomePageFactory.prototype.createFooter = function () {
        return new Footer("Home sayfasi icin footer olusturuldu");
    };
    return HomePageFactory;
}());
// Concrete Factory
var AboutPageFactory = /** @class */ (function () {
    function AboutPageFactory() {
    }
    AboutPageFactory.prototype.createHeader = function () {
        return new Header("About sayfasi icin header olusturuldu");
    };
    AboutPageFactory.prototype.createBody = function () {
        return new Body("About sayfasi icin body olusturuldu");
    };
    AboutPageFactory.prototype.createFooter = function () {
        return new Footer("About sayfasi icin footer olusturuldu");
    };
    return AboutPageFactory;
}());
// Concrete Factory
var ContactPageFactory = /** @class */ (function () {
    function ContactPageFactory() {
    }
    ContactPageFactory.prototype.createHeader = function () {
        return new Header("Contact sayfasi icin header olusturuldu");
    };
    ContactPageFactory.prototype.createBody = function () {
        return new Body("Contact sayfasi icin body olusturuldu");
    };
    ContactPageFactory.prototype.createFooter = function () {
        return new Footer("Contact sayfasi icin footer olusturuldu");
    };
    return ContactPageFactory;
}());
// Creator
var PageCreator = /** @class */ (function () {
    function PageCreator() {
    }
    PageCreator.create = function (pageFactory) {
        var page = new Page();
        page.body = pageFactory.createBody();
        page.footer = pageFactory.createFooter();
        page.header = pageFactory.createHeader();
        return page;
    };
    return PageCreator;
}());
var homePage = PageCreator.create(new HomePageFactory());
homePage.title = "Home";
var aboutPage = PageCreator.create(new AboutPageFactory());
aboutPage.title = "About";
var contactPage = PageCreator.create(new ContactPageFactory());
contactPage.title = "Contact";
