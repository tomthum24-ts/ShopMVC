/*
Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
For licensing, see license.txt or http://cksource.com/ckfinder/license
*/

CKFinder.customConfig = function( config )
{
	// Define changes to default configuration here.
	// For the list of available options, check:
	// http://docs.cksource.com/ckfinder_2.x_api/symbols/CKFinder.config.html

	// Sample configuration options:
	// config.uiColor = '#BDE31E';
	// config.language = 'fr';
	// config.removePlugins = 'basket';

};
 CKEDITOR.on('dialogDefinition', function (ev) {

       var dialogName = ev.data.name,
           dialogDefinition = ev.data.definition;

       if (dialogName == 'image') {
           var onOk = dialogDefinition.onOk;

           dialogDefinition.onOk = function (e) {
               var width = this.getContentElement('info', 'txtWidth');
               width.setValue('0');//Set Default Width

               var height = this.getContentElement('info', 'txtHeight');
               height.setValue('80%');//Set Default height

               onOk && onOk.apply(this, e);
           };
       }
});
