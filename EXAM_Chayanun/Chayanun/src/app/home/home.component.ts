import { Component, OnInit } from '@angular/core';
import { TbAmuletService } from '../service/tb-amulet.service';
import { Router } from '@angular/router';
import { TbAmulet } from '../model/tb-amulet';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  ListTbAmulet =[];
  ErrorMSG ="";
  sugarLevels: Array<TbAmulet>;
  constructor(private TbAmuletSV:TbAmuletService,private route:Router) 
  { 

  }

  ngOnInit() {
    this.initialLoadData();
  }
  
  private initialLoadData(){
    this.TbAmuletSV.GetData().subscribe(items => {
      this.ListTbAmulet = items;
    })
  }

  gotoCreateAmu(){
    this.route.navigate(['/','create-amu']);
  }

  onDeleteData(generation) {
    const result = confirm('ยืนยันการลบ?');
  if (result) {
    const data = {
      generation: generation
    };
   
  }
}
}
