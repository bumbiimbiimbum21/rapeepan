import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { TbAmulet } from '../model/tb-amulet';

@Injectable({
  providedIn: 'root'
})
export class TbAmuletService {

  url ='https://localhost:44391/api/TbAmulets';
  constructor(private http:HttpClient) { }

  GetData(){
    return this.http.get<TbAmulet[]>(this.url);
  }


  createAmu(data) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url + "cmd=insert";
      this.http.post(apiURL, data)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(data);
          }
        );
    });
    return promise;
  }

  deleteAmu(generation: any) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url + "cmd=delete";
      this.http.post(apiURL, generation)
        .toPromise()
        .then(
          res => {
            console.log(res);
            resolve(generation);
          }
        );
    });
    console.log(generation);
    return promise
  }


  getOneGenerate(generation) {
    return this.http.get<TbAmulet[]>(this.url + 'cmd=select&generation=' + generation);
  }

  updateTbAmulet(data) {
    let promise = new Promise((resolve, reject) => {
      let apiURL = this.url + "cmd=update";
      this.http.post(apiURL, data).toPromise().then(
        res => {
          console.log(res);
          resolve(data);
        }
      );
    });
    return promise;
  }



}
