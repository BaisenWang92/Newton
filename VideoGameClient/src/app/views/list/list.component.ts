import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { VideoGameService } from 'src/app/core/services/video-game.service';
import { ModalComponent } from '../modal/modal.component';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  videoGames;
  constructor(private videoGameService: VideoGameService,
    private modalService: NgbModal) { }

  ngOnInit(): void {
    const modalRef = this.modalService.open(ModalComponent);
    modalRef.componentInstance.message = 'Loading';
    this.videoGameService.getVideoGames()
    .subscribe(videoGames => this.videoGames = videoGames,
      error => {},
      () => this.modalService.dismissAll());
  }
}
