"use strict";
// Concrete Product
class ASecurity {
    constructor() {
        console.log(`ASecurity nesnesi olusturuldu`);
    }
}
// Concrete Product
class BSecurity {
    constructor() {
        console.log(`BSecurity nesnesi olusturuldu`);
    }
}
// Concrete Product
class CSecurity {
    constructor() {
        console.log(`CSecurity nesnesi olusturuldu`);
    }
}
// Concrete Factory
class ASecurityFactory {
    createInstance() {
        return new ASecurity();
    }
}
// Concrete Factory
class BSecurityFactory {
    createInstance() {
        return new BSecurity();
    }
}
// Concrete Factory
class CSecurityFactory {
    createInstance() {
        return new CSecurity();
    }
}
// Creator
class SecurityCreator {
    static create(securityType) {
        let securityFactory = null;
        switch (securityType) {
            case SecurityType.A:
                securityFactory = new ASecurityFactory();
                break;
            case SecurityType.B:
                securityFactory = new BSecurityFactory();
                break;
            case SecurityType.C:
                securityFactory = new CSecurityFactory();
                break;
        }
        return securityFactory.createInstance();
    }
}
var SecurityType;
(function (SecurityType) {
    SecurityType[SecurityType["A"] = 0] = "A";
    SecurityType[SecurityType["B"] = 1] = "B";
    SecurityType[SecurityType["C"] = 2] = "C";
})(SecurityType || (SecurityType = {}));
const a1 = SecurityCreator.create(SecurityType.A);
const b1 = SecurityCreator.create(SecurityType.B);
const c1 = SecurityCreator.create(SecurityType.C);
