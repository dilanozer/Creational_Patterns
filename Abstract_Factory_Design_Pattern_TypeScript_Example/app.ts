class Page {
    title!: string;

    header: IHeader | undefined;
    body: IBody | undefined;
    footer: IFooter | undefined;
}

// Abstract Product
interface IHeader {}

// Abstract Product
interface IBody {}

// Abstract Product
interface IFooter {}

// Concrete Product
class Header implements IHeader { 
    constructor(text: string) {console.log(text)}
}

// Concrete Product
class Body implements IBody { 
    constructor(text: string) {console.log(text)}
}

// Concrete Product
class Footer implements IFooter { 
    constructor(text: string) {console.log(text)}
}

// Abstract Factory
interface IPageFactory {
    createHeader(): IHeader;
    createBody(): IBody;
    createFooter(): IFooter;
}

// Concrete Factory
class HomePageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("Home sayfasi icin header olusturuldu");
    }
    createBody(): IBody {
        return new Body("Home sayfasi icin body olusturuldu");
    }
    createFooter(): IFooter {
        return new Footer("Home sayfasi icin footer olusturuldu");
    }
}

// Concrete Factory
class AboutPageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("About sayfasi icin header olusturuldu");
    }
    createBody(): IBody {
        return new Body("About sayfasi icin body olusturuldu");
    }
    createFooter(): IFooter {
        return new Footer("About sayfasi icin footer olusturuldu");
    }
}

// Concrete Factory
class ContactPageFactory implements IPageFactory {
    createHeader(): IHeader {
        return new Header("Contact sayfasi icin header olusturuldu");
    }
    createBody(): IBody {
        return new Body("Contact sayfasi icin body olusturuldu");
    }
    createFooter(): IFooter {
        return new Footer("Contact sayfasi icin footer olusturuldu");
    }
}

// Creator
class PageCreator {
    static create(pageFactory: IPageFactory): Page {
        const page: Page = new Page();
        page.body = pageFactory.createBody();
        page.footer = pageFactory.createFooter();
        page.header = pageFactory.createHeader();
        return page;
    }
}

const homePage: Page = PageCreator.create(new HomePageFactory());
homePage.title = "Home";

const aboutPage: Page = PageCreator.create(new AboutPageFactory());
aboutPage.title = "About";

const contactPage: Page = PageCreator.create(new ContactPageFactory());
contactPage.title = "Contact";