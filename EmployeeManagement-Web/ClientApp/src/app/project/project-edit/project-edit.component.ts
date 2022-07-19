<<<<<<< HEAD
import { Component, OnInit } from '@angular/core';
=======
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AdminComponent } from 'src/app/admin/admin.component';
import { ProjectEditModel } from 'src/app/admin/models/project.model';
import { AdminService } from 'src/app/admin/services/admin.service';
>>>>>>> origin/dev

@Component({
  selector: 'app-project-edit',
  templateUrl: './project-edit.component.html',
  styleUrls: ['./project-edit.component.css']
})
export class ProjectEditComponent implements OnInit {

<<<<<<< HEAD
  constructor() { }

  ngOnInit(): void {
  }

}
=======
  editFormGroup!: FormGroup;
  @Input() projectId: number = 0;
  @Output() getAllProject = new EventEmitter<any>();
  @Output() closeModelEvent = new EventEmitter<any>();


  constructor(private formBuilder: FormBuilder, private adminService: AdminService) { }

  ngOnInit(): void {
    this.editFormGroup = this.formBuilder.group({
      projectName: ["", Validators.required],
      projectDescription: ["", Validators.required],
      projectDuration: ["", Validators.required],
    });
    this.getProjectById(this.projectId);
  }

  getProjectById(id: number) {
    this.adminService.getProjectById(id).subscribe((res) => {
      this.editFormGroup.patchValue(res)
    })
  }

  editProject() {
    let projectEditModel = <ProjectEditModel>{
      projectId: this.projectId,
      projectName: this.editFormGroup.controls['projectName'].value,
      projectDescription: this.editFormGroup.controls['projectDescription'].value,
      projectDuration: this.editFormGroup.controls['projectDuration'].value,
    }
    this.adminService.updateProject(projectEditModel).then((data) => {
      console.log("Updated Successfully")
      this.getAllProject.emit();
      this.closeModelEvent.emit();
    },
      (error) => {
        console.log("Something went wrong");
      }
    )

  }

  get f(): {
    [key: string]: AbstractControl
  } {
    return this.editFormGroup.controls;
  }


}

>>>>>>> origin/dev
