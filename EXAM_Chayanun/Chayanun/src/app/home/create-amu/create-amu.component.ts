import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TbAmuletService } from '../../service/tb-amulet.service';


@Component({
  selector: 'app-create-amu',
  templateUrl: './create-amu.component.html',
  styleUrls: ['./create-amu.component.css']
})
export class CreateAmuComponent implements OnInit {

  errorMsg: string;
  form: FormGroup;
  generation: any;
  items: any;
  errMsg: string;

  constructor(private builder: FormBuilder,
    private router: Router,
    private AmuletSV: TbAmuletService,
    private activateRouter: ActivatedRoute,
    ) { }

  ngOnInit() {
    this.initialCreateFormData();
  }

  private initialCreateFormData() {
    this.form = this.builder.group({

      generation:['', [Validators.required]],
      year:['', [Validators.required]],
      place:['', [Validators.required]],
      price:['', [Validators.required]],
    });
  }

  private initialUpdateFormData() {
    if (!this.generation) { return; }
    this.AmuletSV.getOneGenerate(this.generation)
      .subscribe((data => {
        this.items = data;
        const form = this.form;
        form.controls['generation'].setValue(this.items.rs[0].generation);
        form.controls['year'].setValue(this.items.rs[0].year);
        form.controls['place'].setValue(this.items.rs[0].place);
        form.controls['price'].setValue(this.items.rs[0].price);

      }));
  }


  onSubmit() {

    console.log(this.form.value);
    const patt = /^[a-zA-Zก-ฮ]{2,3000}$/;
    const chk = /^[1-9]{1,100}$/;
    if (this.form.invalid) {
      console.log('ข้อมูลไม่ครบ');
      alert('ข้อมูลไม่ครบ');
    } else if (patt.test(this.form.get('NAME').value) === false) {
      console.log('NAME ผิดพลาด');
      alert('NAME ผิดพลาด');
    } else if (patt.test(this.form.get('LASTNAME').value) === false) {
      console.log('LASTNAME ผิดพลาด');
      alert('LASTNAME ผิดพลาด');
    } else if (chk.test(this.form.get('AGE').value) === false) {
      console.log('AGE ผิดพลาด');
      alert('AGE ผิดพลาด');
    }
    else {
      this.AmuletSV
        .createAmu(JSON.stringify(this.form.value))
        .then(res => {
          this.router.navigate(['/', 'home']);
        })
        .catch(err => this.errorMsg = err);

    }
  }

}
