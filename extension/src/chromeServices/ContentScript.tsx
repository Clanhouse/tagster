import {IdsMessage, UpdateTagsRequest, UpdateTagsResponse} from '../types';
import ReactDOM from 'react-dom';
import React from 'react';
import {Autocomplete, debounce, TextField} from '@mui/material';

const components = new Map<string, JSX.Element>();

function updateComponents(msg: UpdateTagsRequest) {
}

const updateTagsListener = (
    msg: UpdateTagsRequest,
    sender: chrome.runtime.MessageSender,
    sendResponse: (response: UpdateTagsResponse) => void
) => {
  console.log('[content.js]. Message received', msg);

  updateComponents(msg);

  sendResponse({success: true});
};

function onDomUpdate() {
  const message: IdsMessage = {
    type: 'FETCH_IDS',
    ids: [],
  };

  setupReactComponents(getNodesToAttachTo());
  // fetch necessary data here
  if (1 < 0 && isValidChromeRuntime()) {
    chrome.runtime.sendMessage(message, (response: UpdateTagsRequest) => {
      if (response.value) {
        updateComponents(response);
      } else {
        console.log('[content] got empty tags');
      }
    });
  }
}

function isValidChromeRuntime() {
  return chrome.runtime && !!chrome.runtime.getManifest();
}

if (isValidChromeRuntime()) {
  chrome.runtime.onMessage.addListener(updateTagsListener);
}

const observer = new MutationObserver(debounce(onDomUpdate, 400));
observer.observe(document, {
  attributes: true,
  childList: true,
  subtree: true,
});

const tagsPlaceholder = [
  {id: 'asd', name: 'Tag 1'},
  {id: 'asd2', name: 'Tag 2'},
  {id: 'asd3', name: 'A tag 1'},
  {id: 'asd4', name: 'Whatever 1'},
  {id: 'asd5', name: 'Bs 1'},
  {id: 'asd6', name: 'Kekezaur 1'},
  {id: 'asd7', name: 'Taggeroni 1'},
];

function getXpathResult(expression: string) {
  return document.createExpression(expression)
  .evaluate(document.getElementsByTagName("body")[0]);
}

function addResults(xPathResult: XPathResult, resArray: { node: Node; link: string }[], link: string) {
  let result = xPathResult.iterateNext();
  while (result) {
    resArray.push({node: result, link});
    result = xPathResult.iterateNext();
  }
}

function getNodesForTopCard(resArray: { node: Node, link: string }[]) {
  const xPathResult = getXpathResult("//section[contains(@class,'top-card')]//div[contains(@class,'mt2')]");
  addResults(xPathResult, resArray, window.location.href.substring(window.location.href.indexOf("linkedin.com") + 12));
}

function getNodesForFeedPopups(resArray: { node: Node; link: string }[]) {
  const xPathResult = getXpathResult("//div[contains(@class, 'entity-hovercard')]");
  const result = xPathResult.iterateNext() as Element;
  if (result) {
    const aElements = result.getElementsByTagName("a");
    const divElements = result.getElementsByTagName("div");
    if (aElements.length > 0 && divElements.length > 0) {
      const link = aElements.item(0)!.href;
      resArray.push({node: divElements.item(divElements.length - 1) as Node, link: link})
    }
  }
}

function getNodesToAttachTo() {
  const resArray: { node: Node, link: string }[] = [];
  //top card (main page)
  getNodesForTopCard(resArray);
  getNodesForFeedPopups(resArray);
  return resArray;
}

function setupReactComponents(componentsData: { node: Node, link: string }[]) {
  for (const componentData of componentsData) {
    if (!components.has(componentData.link)) {
      const divElement = document.createElement("div");
      componentData.node.appendChild(divElement);
      const autocompleteComponent = <Autocomplete
          multiple
          limitTags={4}
          id={'multiple-limit-tags-' + Math.floor(Math.random() * 500000)}
          options={tagsPlaceholder}
          getOptionLabel={(option) => option.name}
          defaultValue={[tagsPlaceholder[0], tagsPlaceholder[1]]}
          renderInput={(params) => <TextField {...params} label='Tags'
                                              placeholder='Add tag...'/>}
          sx={{width: '300px'}}
      />;
      ReactDOM.render(
          <React.StrictMode>
            {autocompleteComponent}
          </React.StrictMode>,
          divElement
      );
      components.set(componentData.link, autocompleteComponent);
    }
  }
}
