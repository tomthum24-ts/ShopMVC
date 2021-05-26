/**
 * @license Copyright (c) 2003-2020, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Public/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Public/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Public/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Public/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Public/Images';
    config.filebrowserFlashUploadUrl = '/Public/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    CKFinder.setupCKEditor(null, '/Public/ckfinder/');
};