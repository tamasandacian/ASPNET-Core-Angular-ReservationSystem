import { Component, OnInit } from '@angular/core';
import { NgbCarouselConfig } from '@ng-bootstrap/ng-bootstrap';  

@Component({
  selector: 'app-carousel',
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.css']
})
export class CarouselComponent implements OnInit {

  constructor(config: NgbCarouselConfig) {
    config.interval = 7000;  
    config.wrap = true;  
    config.keyboard = false;  
    config.pauseOnHover = false;  
   }

  ngOnInit() {
    
  }

}
