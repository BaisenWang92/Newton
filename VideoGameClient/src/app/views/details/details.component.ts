import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbAlertConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { VideoGame } from 'src/app/core/models/video-game';
import { VideoGameService } from 'src/app/core/services/video-game.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  @Input() videoGame: VideoGame;
  videoGameForm: FormGroup;

  get name() {
    return this.videoGameForm.get('name');
  }

  get description() {
    return this.videoGameForm.get('description');
  }

  get platforms() {
    return this.videoGameForm.get('platforms');
  }

  get publisher() {
    return this.videoGameForm.get('publisher');
  }

  get gameType() {
    return this.videoGameForm.get('gameType');
  }


  platformOptions = [];
  dropdownSettings: IDropdownSettings = {};
  publisherOptions = [];
  gameTypeOptions = [];

  isSubmitting = false;

  constructor(private fb: FormBuilder, 
    private alertConfig: NgbAlertConfig,
    private videoGameService: VideoGameService,
    private modalService: NgbModal) {
    alertConfig.type = 'danger';
    alertConfig.dismissible = false;
  }

  ngOnInit(): void {
    this.videoGameService.getPlatforms()
    .subscribe(platforms => {
      this.platformOptions = this.videoGameService.platformListToOptions(platforms)
    });

    this.dropdownSettings = {
      singleSelection: false,
      idField: 'key',
      textField: 'value',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };

    this.videoGameService.getPublishers()
    .subscribe(publishers => {
      this.publisherOptions = this.videoGameService.publisherListToOptions(publishers)
    });

    this.gameTypeOptions = this.videoGameService.gameTypeListToOptions(this.videoGameService.getGameTypes());

    this.videoGameForm = this.fb.group({
      name: [this.videoGame.name, [Validators.required, Validators.maxLength(50)]],
      description: [this.videoGame.description, [Validators.maxLength(255)]],
      platforms: [this.videoGameService.platformListToOptions(this.videoGame.platforms), [Validators.required]],
      publisher: [this.videoGame.publisher.id, [Validators.required]],
      gameType: [this.videoGame.gameType, [Validators.required]],
    });
  }

  save(){
    alert("save fn");
  }

}