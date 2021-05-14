document.addEventListener('DOMContentLoaded', function() {
    var checkPageButton = document.getElementById('searchNames');
    checkPageButton.addEventListener('click', function() {  
      chrome.tabs.getSelected(null, function() 
      {
              xpath = "//a[contains(@class,'actor') or contains(@data-control-name,'actor')]/@href"; //version for homepage
              parent = document;
              let results = [];
              let query = document.evaluate(xpath,parent,null,XPathResult.ORDERED_NODE_SNAPSHOT_TYPE,null);
              for (let i = 0, length = query.snapshotLength; i < length; ++i) 
              {
                  results.push(query.snapshotItem(i));
                  console.log(query.snapshotItem(i)); //return results to the console
              }
              return results;
              
               
      });
    }, false);
  }, false);
  
   
  
  