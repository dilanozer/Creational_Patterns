var YemekTipi;
(function (YemekTipi) {
    YemekTipi[YemekTipi["Sulu"] = 0] = "Sulu";
    YemekTipi[YemekTipi["Etli"] = 1] = "Etli";
    YemekTipi[YemekTipi["Sebzeli"] = 2] = "Sebzeli";
})(YemekTipi || (YemekTipi = {}));
//Concrete Builder
var SuluYemekBuilder = /** @class */ (function () {
    function SuluYemekBuilder() {
        this.yemek = new Yemek();
    }
    SuluYemekBuilder.prototype.setYemekTipi = function () {
        this.yemek.yemekTipi = YemekTipi.Sulu;
        return this;
    };
    SuluYemekBuilder.prototype.setYemekAdi = function () {
        this.yemek.yemekAdi = "Sulu yemek";
        return this;
    };
    SuluYemekBuilder.prototype.setTuzOrani = function () {
        this.yemek.tuzOrani = 3;
        return this;
    };
    return SuluYemekBuilder;
}());
var EtliYemekBuilder = /** @class */ (function () {
    function EtliYemekBuilder() {
        this.yemek = new Yemek();
    }
    EtliYemekBuilder.prototype.setYemekTipi = function () {
        this.yemek.yemekTipi = YemekTipi.Etli;
        return this;
    };
    EtliYemekBuilder.prototype.setYemekAdi = function () {
        this.yemek.yemekAdi = "Etli yemek";
        return this;
    };
    EtliYemekBuilder.prototype.setTuzOrani = function () {
        this.yemek.tuzOrani = 5;
        return this;
    };
    return EtliYemekBuilder;
}());
var SebzeliYemekBuilder = /** @class */ (function () {
    function SebzeliYemekBuilder() {
        this.yemek = new Yemek();
    }
    SebzeliYemekBuilder.prototype.setYemekTipi = function () {
        this.yemek.yemekTipi = YemekTipi.Sebzeli;
        return this;
    };
    SebzeliYemekBuilder.prototype.setYemekAdi = function () {
        this.yemek.yemekAdi = "Sebzeli yemek";
        return this;
    };
    SebzeliYemekBuilder.prototype.setTuzOrani = function () {
        this.yemek.tuzOrani = 1;
        return this;
    };
    return SebzeliYemekBuilder;
}());
//Director
var YemekDirector = /** @class */ (function () {
    function YemekDirector() {
    }
    YemekDirector.prototype.yemekYap = function (yemekBuilder) {
        return yemekBuilder.setTuzOrani().setYemekAdi().setYemekTipi().yemek;
    };
    return YemekDirector;
}());
//Product
var Yemek = /** @class */ (function () {
    function Yemek() {
    }
    Yemek.prototype.tarifiGoster = function () {
        console.log("Yemek Tipi: ".concat(this.yemekTipi, " -> Yemek Ad\u0131: ").concat(this.yemekAdi, " -> Tuz Oran\u0131: ").concat(this.tuzOrani));
    };
    return Yemek;
}());
var director = new YemekDirector();
var sulu = director.yemekYap(new SuluYemekBuilder());
var etli = director.yemekYap(new EtliYemekBuilder());
var sebzeli = director.yemekYap(new SebzeliYemekBuilder());
sulu.tarifiGoster();
etli.tarifiGoster();
sebzeli.tarifiGoster();
