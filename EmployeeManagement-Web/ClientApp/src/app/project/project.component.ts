import { Component, OnInit } from '@angular/core';
import { AdminService } from '../admin/services/admin.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit 
{
  projectData: any;
  router: any;

  constructor(private adminService:AdminService) {
    this.getAllProject();
   }

  ngOnInit(): void {
  }
  getAllProject(){
    this.adminService.getAllProject().subscribe((p)=>
    {
      debugger;
      this.projectData = p;
    }
    )
  }
 editAllProjects()
 {
  debugger;
  this.router.navigate(["Project/edit-project"])

 }
}



