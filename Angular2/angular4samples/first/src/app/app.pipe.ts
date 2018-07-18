import {Pipe, PipeTransform} from "@angular/core"

@Pipe ({
    name: "sort"
})

export class SortPipe implements PipeTransform
{
    transform(value: any[], order: string): any {
        if(order === "asce")
        {
            return value.sort();
        }
        else if(order === "desc")
        {
            return value.sort().reverse();
        }
    }
}

