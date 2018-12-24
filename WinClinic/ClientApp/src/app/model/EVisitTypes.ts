export enum EVisitTypes {
  Acute = 0, Chronic, Follow_Up, Referral, Review
}

export function VisitTypes(): string[] {
  let visits: string[] = [];
  for (var v in EVisitTypes) {
    if (typeof EVisitTypes[v] !== 'number')
      visits.push(EVisitTypes[v]);
  }
  return visits;
}
