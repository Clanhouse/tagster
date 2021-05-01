var paragraphCount = document.evaluate( 'count(//p)', document, null, XPathResult.ANY_TYPE, null );

alert( 'This document contains ' + paragraphCount.numberValue + ' paragraph elements' );
