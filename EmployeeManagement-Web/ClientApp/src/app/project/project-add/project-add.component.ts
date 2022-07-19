import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { ProjectModel } from 'src/app/admin/models/project.model';
import { AdminService } from 'src/app/admin/services/admin.service';


@Component({
  selector: 'app-project-add',
  templateUrl: './project-add.component.html',
  styleUrls: ['./project-add.component.css']
})
export class ProjectAddComponent implements OnInit {

  saveProjectForm!:FormGroup;
  submitted: boolean =false;
  projectModel!: ProjectModel;

  constructor(private formBuilder:FormBuilder, private adminService:AdminService, private router:Router) { }

  ngOnInit(): void {
    this.saveProjectForm = this.formBuilder.group({
      pname:["" ,Validators.required],
      description:[" ",Validators.required],
      duration:[" ",Validators.required],
    });
  }
  get f():{
    [key:string]:AbstractControl
  }
  {
    return this.saveProjectForm.controls;
  }
  createProject(){
    
    this.submitted =true;
    if (this.saveProjectForm.valid)
    {
      const pname = this.saveProjectForm.controls['pname'].value;
      const description = this.saveProjectForm.controls['description'].value;
      const duration = this.saveProjectForm.controls['duration'].value;
     this.projectModel = {
      projectName: pname,
      projectDescription: description,
      projectDuration: parseInt(duration)
     };
     this.adminService.saveProject(this.projectModel)
     .pipe(first())
     .subscribe(
      data =>{
        this.router.navigate(['/admin/Project']);
      }
     )
    }
}

}
