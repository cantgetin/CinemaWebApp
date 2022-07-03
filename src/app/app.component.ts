import { Component } from '@angular/core';
import $, { data } from 'jquery';


      
@Component({
    selector: 'my-app',
    template: `<h1>Проверить {{appName}}</h1>
                <input ng-click="getSearch()" type="button" value="lol"/>`
})

export class AppComponent { 
    appName = 'ASPcinema';
}

function getSearch() {
    //console.log($("#query").val())
    //console.log(typeof ($("#query").val()))
    var result = null;
    $.get("https://localhost:44369/Home/GetFilmsCount", function (data, status) {
        alert("Количество фильмов: " + data + "\nСтатус запроса: " + status);
    });
}
