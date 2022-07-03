var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import $ from 'jquery';
var AppComponent = /** @class */ (function () {
    function AppComponent() {
        this.appName = 'ASPcinema';
    }
    AppComponent = __decorate([
        Component({
            selector: 'my-app',
            template: "<h1>\u041F\u0440\u043E\u0432\u0435\u0440\u0438\u0442\u044C {{appName}}</h1>\n                <input ng-click=\"getSearch()\" type=\"button\" value=\"lol\"/>"
        })
    ], AppComponent);
    return AppComponent;
}());
export { AppComponent };
function getSearch() {
    //console.log($("#query").val())
    //console.log(typeof ($("#query").val()))
    var result = null;
    $.get("https://localhost:44369/Home/GetFilmsCount", function (data, status) {
        alert("Количество фильмов: " + data + "\nСтатус запроса: " + status);
    });
}
//# sourceMappingURL=app.component.js.map