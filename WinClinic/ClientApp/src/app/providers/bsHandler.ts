import { HttpErrorResponse } from "@angular/common/http";

export class bsHandler {
  hand: IHand;

  constructor() {
    this.hand = { isDismissed: true, isError: false, isProcessing: false, message: '' };
  }
  beginProc(): void {
    this.hand.isProcessing = true;
    this.hand.isDismissed = true;
    this.hand.isError = false;
  }

  endProc(): void {
    this.hand.isProcessing = false;
    this.hand.isDismissed = this.hand.isError ? true : false;
  }


  onError(err: HttpErrorResponse) {
    if (err.error!.message) {
      this.hand.message = err.error.message;
    }
    else {
      switch (err.status) {
        case 500:
          this.hand.message = "A server error occurred. Contact support";
          break;
        case 400:
          this.hand.message = err.error!.message;
          break;
        default:
          this.hand.message = "An unexpected error occurred. Contact support";
          break;
      }
    }
    this.hand.isError = true;
    alert(this.hand.message);
  }
}
export interface IHand {
  message:string
  isProcessing: boolean;
  isError: boolean;
  isDismissed: boolean;
}
