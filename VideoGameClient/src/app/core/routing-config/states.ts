import { DetailsComponent } from "src/app/views/details/details.component";
import { ListComponent } from "src/app/views/list/list.component";
import { Transition } from "@uirouter/core";
import { VideoGameService } from "../services/video-game.service";


export const listState = { name: "list", url: "/list", component: ListComponent };
export const detailsState = { 
    name: "details", 
    url: "/details/:id", 
    component: DetailsComponent,
    resolve: [
        {
            token: "videoGame",
            deps: [Transition, VideoGameService],
            resolveFn: (trans: Transition, videoGameService: VideoGameService) =>
                videoGameService.getVideoGames().toPromise()
                .then(videoGames => {
                    return videoGames.find(videoGame => videoGame.id == trans.params().id)
                })
        }
    ]
 };