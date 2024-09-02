enum YemekTipi {
    Sulu, Etli, Sebzeli
}

//Abstract Builder
interface IYemekBuilder {
    yemek: Yemek;

    setYemekTipi(): IYemekBuilder;
    setYemekAdi(): IYemekBuilder;
    setTuzOrani(): IYemekBuilder;
}

//Concrete Builder
class SuluYemekBuilder implements IYemekBuilder {
    yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this.yemek.yemekTipi = YemekTipi.Sulu;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this.yemek.yemekAdi = "Sulu yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this.yemek.tuzOrani = 3;
        return this;
    }

}

class EtliYemekBuilder implements IYemekBuilder {
    yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this.yemek.yemekTipi = YemekTipi.Etli;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this.yemek.yemekAdi = "Etli yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this.yemek.tuzOrani = 5;
        return this;
    }

}

class SebzeliYemekBuilder implements IYemekBuilder {
    yemek: Yemek = new Yemek();

    setYemekTipi(): IYemekBuilder {
        this.yemek.yemekTipi = YemekTipi.Sebzeli;
        return this;
    }
    setYemekAdi(): IYemekBuilder {
        this.yemek.yemekAdi = "Sebzeli yemek";
        return this;
    }
    setTuzOrani(): IYemekBuilder {
        this.yemek.tuzOrani = 1;
        return this;
    }

}

//Director
class YemekDirector {
    yemekYap(yemekBuilder: IYemekBuilder): Yemek {
        return yemekBuilder.setTuzOrani().setYemekAdi().setYemekTipi().yemek;
    }
}

//Product
class Yemek {
    yemekTipi: YemekTipi | any;
    yemekAdi: string | any;
    tuzOrani: number | any;

    tarifiGoster() {
        console.log(`Yemek Tipi: ${this.yemekTipi} -> Yemek Adı: ${this.yemekAdi} -> Tuz Oranı: ${this.tuzOrani}`);
    }
}

const director: YemekDirector = new YemekDirector();
const sulu = director.yemekYap(new SuluYemekBuilder());
const etli = director.yemekYap(new EtliYemekBuilder());
const sebzeli = director.yemekYap(new SebzeliYemekBuilder());

sulu.tarifiGoster();
etli.tarifiGoster();
sebzeli.tarifiGoster();