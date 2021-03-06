import { Injectable } from '@angular/core';
// var jQuery = require('jquery')
declare var jquery: any;
declare var $: any;

@Injectable()
export class PrintProviderService {

  print(elem: string, title?: string, head?: string) {
    const table = $(`#${elem}`);
    table.printThis({
      debug: false,               // show the iframe for debugging
      importCSS: true,            // import page CSS
      importStyle: true,         // import style tags
      printContainer: true,       // grab outer container as well as the contents of the selector
      //  loadCSS: "path/to/my.css",  // path to additional css file - use an array [] for multiple
      pageTitle: title,              // add title to print page
      removeInline: false,        // remove all inline styles from print elements
      printDelay: 30,            // variable print delay; depending on complexity a higher value may be necessary
      header: `<h1 style="text-align:center" class="h1">${title}</h1>
<br />
<h2 style="text-align:center">${head}</h2>`,               // prefix to html
      footer: `<footer>Monthly Income Report</footer>`,               // postfix to html
      base: false,               // preserve the BASE tag, or accept a string for the URL
      formValues: true,           // preserve input/form values
      canvas: false,              // copy canvas elements (experimental)
      //   doctypeString: "...",       // enter a different doctype for older markup
      removeScripts: false,       // remove script tags from print content
      copyTagClasses: false       // copy classes from the html & body tag
    });
  }
}
