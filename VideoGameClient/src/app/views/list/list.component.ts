import { Component, OnInit } from '@angular/core';
import { VideoGameService } from 'src/app/core/services/video-game.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  videoGames;
  constructor(private videoGameService: VideoGameService) { }

  ngOnInit(): void {
    this.videoGameService.getVideoGames()
    .subscribe(videoGames => this.videoGames = videoGames,
      error => {},
      () => {});
  }
}
