document.addEventListener('DOMContentLoaded', function() {
  var checkPageButton = document.getElementById('searchNames');
  checkPageButton.addEventListener('click', function() {  
      function searchNames() {
          console.log('List of people:');       
          xpath = "//a[contains(@class,'actor') or contains(@class,'entity-type-card') or contains(@class,'ember-view msg-conversation')]/@href"; //version for homepage
                parent = document;
                let results = [];
                let query = document.evaluate(xpath,parent,null,XPathResult.ORDERED_NODE_SNAPSHOT_TYPE,null);
                for (let i = 0, length = query.snapshotLength; i < length; ++i) 
                {
                    results.push(query.snapshotItem(i));
                    console.log(query.snapshotItem(i)); //return results to the console
                }
                return results;        
      }   
      chrome.tabs.executeScript({
          code: '(' + searchNames + ')();' //argument here is a string but function.toString() returns function's code
      });    
  }, false);
}, false);