/**
 * @license Copyright (c) 2003-2019, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    //config.allowedContent =
    //    'h1 h2 h3 p blockquote strong em;' +
    //    'a[!href];' +
    //    'img(left,right)[!src,alt,width,height];';
    config.entities_latin = false;
    config.entities_greek = false;
    config.entities = false;
    config.basicEntities = false; 

    //config.htmlEncodeOutput = true;
    //config.htmlDecodeOutout = true;
};
