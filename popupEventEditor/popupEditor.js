console.log("Check");
class ClassWatcher {

    constructor(targetNode, classToWatch, classAddedCallback, classRemovedCallback) {
        this.targetNode = targetNode
        this.classToWatch = classToWatch
        this.classAddedCallback = classAddedCallback
        this.classRemovedCallback = classRemovedCallback
        this.observer = null
        this.lastClassState = targetNode.classList.contains(this.classToWatch)
        this.alreadyAdded = false;
        this.alreadyRemoved = false;
        this.init()
    }

    init() {
        this.observer = new MutationObserver(this.mutationCallback)
        this.observe()
    }

    observe() {
        this.observer.observe(this.targetNode, { attributes: true })
    }

    disconnect() {
        this.observer.disconnect()
    }

    mutationCallback = mutationsList => {
        for (let mutation of mutationsList) {
            if (mutation.type === 'attributes' && mutation.attributeName === 'class') {
                let currentClassState = mutation.target.classList.contains(this.classToWatch)
                if (this.lastClassState !== currentClassState) {
                    this.lastClassState = currentClassState
                    if (currentClassState) {
                        if (!this.alreadyAdded) {
                            this.classAddedCallback();
                            this.alreadyAdded = true;
                        }
                    } else {
                        if (!this.alreadyRemoved) {
                            this.classRemovedCallback();
                            this.alreadyRemoved = true;
                        }
                    }
                }
            }
        }
    }
}

function workOnClassAdd(hoverCardElement) {
    const elem = document.createElement("p");
    elem.innerHTML = "Tagster";
    elem.className = "tagster-tags";
    hoverCardElement.appendChild(elem);
}


function workOnClassRemoval() {
    //alert("I'm triggered when the class is removed")
}
let hoverCardNodes = document.getElementsByClassName('entity-hovercard')
for (const hoverCardNode of hoverCardNodes) {
    new ClassWatcher(hoverCardNode, 'active', () => workOnClassAdd(hoverCardNode), workOnClassRemoval)
}