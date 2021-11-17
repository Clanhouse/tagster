xpath = "//a[@class='app-aware-link feed-shared-actor__container-link relative display-flex flex-grow-1']/@href";
parent = document;
function GetPersonID(xpath, parent)
{ 
    let results = [];
    let query = document.evaluate(xpath,parent,null,XPathResult.ORDERED_NODE_SNAPSHOT_TYPE,null);
    for (let i = 0, length = query.snapshotLength; i < length; ++i) {
        results.push(query.snapshotItem(i));
    }
    return results;
  
}
