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
  isUpdateProject: boolean = false;
  projectId: number = 0;

  constructor(private adminService:AdminService, private router:Router) {
    this.getAllProject();
   }

  ngOnInit(): void {
  }
  getAllProject(){
    this.adminService.getAllProject().subscribe((p)=>
    {
       this.projectData = p;
    }
    )
  }
 editAllProjects()
 {
this.router.navigate(["Project/edit-project"])
}
 addProject(){
  this.router.navigate(["/admin/Project/add-project"])
 }
}
    

  deleteProject(projectid: number){
    this.adminService.deleteProject(projectid).subscribe((d)=>{
      if (d == 200)
        console.log("Deleted Successfully")
      else
        console.log("This record is not Found")
      this.getAllProject();
    })
    }

    updateProject(projectId: number){
      this.projectId=projectId;
      this.isUpdateProject=true;
  }

  // closeModelEvent() {
  //   this.isUpdateProject = false;
  // }

