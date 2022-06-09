export class Parameter {
    constructor(label: string, name: string, value: string) {
        this.label = label;
        this.name = name;
        this.value = value;
    }

    public label: string;
    public name: string;
    public value: string;
}