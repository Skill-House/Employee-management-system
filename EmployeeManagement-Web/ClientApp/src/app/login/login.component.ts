import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { UserModel } from '../admin/models/user.model';
import { AdminService } from '../admin/services/admin.service';
import { AuthenticationService } from '../core/service/authentication.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  saveUser!: FormGroup;
  userModel!: UserModel;
  submitted: Boolean = false;
  roleData: any;
  
  constructor( private formBuilder: FormBuilder,  private authenticationService: AuthenticationService,private router: Router, private adminService:AdminService) 
  {
    this.getAllRoles(); }
   
  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
    });
    debugger;
    this.saveUser= this.formBuilder.group({
      username: ["", Validators.required],
      password: ["", Validators.required],
      email: ["", Validators.required],
      roleName:["",Validators.required],
      }
    );
  }
  get f(): { [key: string]: AbstractControl } {
    return this.loginForm.controls;
   
   }
     
  login() {
     this.submitted = true;
    if (this.loginForm.invalid)
      return;
      const userName = this.loginForm.value.username;
      const passWord = this.loginForm.value.password;
        this.authenticationService.login(userName, passWord)
      .subscribe(
        (data) => {
          this.router.navigate(["/admin"]);
      
        })
      }  
    
  
  createUser(){
    debugger;
    this.submitted =true;
    if(this.saveUser.invalid)
    return;
    const userName1 =this.saveUser.value.username;
    const passWord1 =this.saveUser.value.password;
    const Email1 =this.saveUser.value.email; 
    const RoleId = this.saveUser.value.roleName;
    this.userModel = {
      firstName: userName1,
      passWord: passWord1,
      userEmail:Email1,
      roleId:parseInt(RoleId),
    };
    
    this.adminService.saveUser(this.userModel)
    .pipe(first())
    .subscribe(
      data=>{
        this.router.navigate(['login'])
      }
    )
    
  }
 getAllRoles(){
  this.adminService.getAllRoles().subscribe((r)=>
  {
  
    this.roleData=r;
  })
 }
}